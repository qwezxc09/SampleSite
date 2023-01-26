import { Component, OnInit } from '@angular/core';
import { CraneService } from '../../services/crane.service';
import { DatePipe } from '@angular/common';
import { Display_NSI, ZAR_STATES_REPORT } from '../../Model/Models';
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Component({
  selector: 'app-crane-report-data',
  templateUrl: './crane-report-data.component.html',
  styleUrls: ['./crane-report-data.component.css']
})
export class CraneReportDataComponent implements OnInit {

  constructor(public craneService: CraneService, private datePipe: DatePipe) { }

  isError: boolean;
  showCraneFlag: boolean;
  filterUseFlag: boolean;
  errorMsg: string;
  errorValue: any[];
  ru: any;
  locale: any;

  loading: boolean;
  loadingExcel: boolean;
  loadingLpu: boolean;
  loadingKp: boolean;
  tableValue: any;
  tableValueRearrange: any;
  tableValueAll: any;

  dateStart: Date;
  dateEnd: Date;

  lpus: Display_NSI[];
  selectedLpu: Display_NSI;

  kps: any;
  selectedKp: Display_NSI;

  startInterval: number;
  endInterval: number;

  localizations: any;

  ngOnInit() {

    this.ru = {
      firstDayOfWeek: 1,
      dayNames: ["Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"],
      dayNamesShort: ["Пон", "Втр", "Срд", "Чтв", "Птн", "Сбт", "Вск"],
      dayNamesMin: ["Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"],
      monthNames: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
      monthNamesShort: ["Янв", "Фвр", "Мар", "Апр", "Май", "Июн", "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"],
      today: 'Сегодня',
      clear: 'Очистить'
    };
    this.isError = false;
    this.showCraneFlag = false;
    this.filterUseFlag = true;
    this.errorValue = [];
    this.tableValue = [];
    this.tableValueAll = [];
    this.tableValueRearrange = [];
    this.loading = false;
    this.loadingExcel = false;
    this.startInterval = 0;
    this.endInterval = 0;
    this.lpus = [];
    this.kps = [];
    this.dateStart = new Date();
    this.dateEnd = new Date();
    this.dateStart.setDate(this.dateEnd.getDate() - 1)
    this.loadingKp = true;
    this.loadingLpu = true;
    setTimeout(() => {
      this.craneService.GetLpuList().subscribe(data => {
        this.lpus = data;
        this.selectedLpu = this.lpus[0];
        this.loadingLpu = false;
      }, error => console.error(error));
    }, 1000);
    setTimeout(() => {
      this.craneService.GetKPList("").subscribe(data => {
        this.kps = data;
        this.selectedKp = this.kps[0];
        this.loadingKp = false;
      }, error => console.error(error));
    }, 1000);

  }

  createReport() {
    this.loading = true;
    this.showCraneFlag = false;
    if (this.selectedLpu.NsiValue == "Все ЛПУ")
      this.filterUseFlag = false;
    else
      this.filterUseFlag = true;
    var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
    var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
    var dataReport = this.craneService.CreateCraneDataReport(datestart, dateend, this.selectedLpu.NsiValue, this.selectedKp.NsiValue);
    setTimeout(() => {
      dataReport.subscribe(data => {
        this.tableValue = data;
        this.tableValueAll = data;
        this.tableValueRearrange = this.tableValue.filter(u => u.isNoValue == false);
        this.errorValue = this.tableValue.filter(u => u.isError == true);
        if (this.errorValue.length > 0) {
          this.errorMsg = this.errorValue[0].errorMessage;
          this.isError = true;
        }
        this.loading = false;
      }, error => console.error(error))
    }, 1000)
  }
  clearFilters() {
    this.selectedKp = this.kps[0];
    this.selectedLpu = this.lpus[0];
    this.dateStart = new Date();
    this.dateEnd = new Date();
    this.dateStart.setDate(this.dateEnd.getDate() - 1)
  }
  changeLPU() {
    this.loadingKp = true;
    setTimeout(() => {
      this.craneService.GetKPList(this.selectedLpu.NsiValue).subscribe(data => {
        this.kps = data;
        this.loadingKp = false;
      })
    }, 1000)
  }
  showOnlyRearrangedCranes() {
    this.showCraneFlag = true;
    this.tableValue = this.tableValueRearrange;
  }
  showAllCranes() {
    this.showCraneFlag = false;
    this.tableValue = this.tableValueAll;
  }
  createExcelReport() {
    this.loadingExcel = true;
    var datestart = this.dateStart.toLocaleDateString();
    var dateend = this.dateEnd.toLocaleDateString();
    var dataReport = this.craneService.CreateXLSfile(datestart, dateend, this.selectedLpu.NsiValue, this.selectedKp.NsiValue, !this.showCraneFlag);
    setTimeout(() => {
      dataReport.subscribe(data => {
        this.saveAsExcelFile(data, "Контроль перестановки кранов");
        this.loadingExcel = false;
      }, error => console.error(error))
    }, 1000)
  }
  private saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
  }
}
