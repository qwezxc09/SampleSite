import { HttpClient } from '@angular/common/http';
import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Lpu_NSI } from '../Model/Models';
import { FullDataControlService } from '../Services/full-data-control.service';
import * as FileSaver from 'file-saver';
import { isError } from 'util';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Component({
  selector: 'app-full-data-control',
  templateUrl: './full-data-control.component.html',
  styleUrls: ['./full-data-control.component.css']
})
export class FullDataControlComponent implements OnInit {
  loading: boolean;
  loadingExcel: boolean;
  loadingButton: boolean;
  isError: boolean;
  errorMsg: string;
  ru: any;
  ru2: any;

  dateStart: Date;
  dateEnd: Date;
  getTableData: DisplayPeriodsValue;

  itogFooter: any;

  lpus: Lpu_NSI[];
  selectedLpus: Lpu_NSI[];

  serverValue: DisplayPeriodsValue;



  tableValue: any;
  frozenValue: any;
  errorValue: any[];

  dateNow: Date;

  value1: string = "off";
  date3: Date;
  localizations: any;

  constructor(public fdService: FullDataControlService, private router: Router) {
  }

  dataTypes: dataType[];
  sales: any[];
  selectedData: dataType;

  lastYearTotal: number;


  thisYearTotal: number;
  ngOnInit(): void {
    this.isError = false;
    this.serverValue = { tableValue: [], frozenRaws:[] };
    this.dateStart = new Date();
    this.dateEnd = new Date();
    this.dateStart.setHours(this.dateEnd.getHours() - 2);
    this.loading = false;
    this.selectedLpus = [];
    this.errorValue = [];
    this.lpus = [];
    this.itogFooter = {};
    this.loadingButton = true;
    this.loadingExcel = false;
    setTimeout(() => {
      this.fdService.GetLpuList().subscribe(data => {
        this.lpus = data;
        this.loadingButton = false;
      }, error => console.error(error));
    }, 1000)
    console.log(this.selectedLpus)
    this.dateNow = new Date();


    this.selectedData = { name: 'Данные за сутки', value: 2 };

    this.dataTypes = [
      { name: 'Текущие', value: 1 },
      { name: 'Данные за сутки', value: 2 },
      { name: 'Данные за период', value: 3 },
    ];

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

  }

  getData() {
    this.loading = true;
    if (this.selectedData.value === 3) {
      var datestart = this.dateStart.toLocaleDateString();
      var dateend = this.dateEnd.toLocaleDateString();

      var dataReport = this.fdService.CreateReportPeriod(datestart, dateend, this.selectedLpus);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.serverValue = data as DisplayPeriodsValue;
          this.itogFooter = this.serverValue.frozenRaws[0];
          this.errorValue = this.serverValue.tableValue.filter(u => u.isError == true);
          if (this.errorValue.length > 0) {
            this.errorMsg = this.errorValue[0].errorMessage;
            this.isError = true;
          }
          this.loading = false;
        }, error => console.error(error))
      }, 1000)
    }
    else if (this.selectedData.value === 2) {
      var datestart = this.dateStart.toLocaleDateString();
      var dateend = this.dateEnd.toLocaleDateString();

      var dataReport = this.fdService.CreateReportDay(datestart, dateend, this.selectedLpus);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.serverValue = data as DisplayPeriodsValue;
          this.itogFooter = this.serverValue.frozenRaws[0];
          this.errorValue = this.serverValue.tableValue.filter(u => u.isError == true);
          if (this.errorValue.length > 0) {
            this.errorMsg = this.errorValue[0].errorMessage;
            this.isError = true;
          }
          this.loading = false;
        }, error => console.error(error))
      }, 1000)
    }
    else if (this.selectedData.value === 1) {

      var dataReport = this.fdService.CreateReportLive(this.selectedLpus);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.serverValue = data as DisplayPeriodsValue;
          this.itogFooter = this.serverValue.frozenRaws[0];
          this.errorValue = this.serverValue.tableValue.filter(u => u.isError == true);
          if (this.errorValue.length > 0) {
            this.errorMsg = this.errorValue[0].errorMessage;
            this.isError = true;
          }
          this.loading = false;
        }, error => console.error(error))
      }, 1000)
    }
  }
  createExcelReport() {
    this.loadingExcel = true;
    if (this.selectedData.value === 3) {
      var datestart = this.dateStart.toLocaleDateString();
      var dateend = this.dateEnd.toLocaleDateString();

      var dataReport = this.fdService.CreateXLSfilePeriod(datestart, dateend, this.selectedLpus);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.saveAsExcelFile(data, "Контроль полноты сбора данных (Период)");
          this.loadingExcel = false;
        }, error => console.error(error))
      }, 1000)
    }
    else if (this.selectedData.value === 2) {
      var datestart = this.dateStart.toLocaleDateString();
      var dateend = this.dateEnd.toLocaleDateString();

      var dataReport = this.fdService.CreateXLSfileDay(datestart, dateend, this.selectedLpus);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.saveAsExcelFile(data, "Контроль полноты сбора данных (Сутки)");
          this.loadingExcel = false;
        }, error => console.error(error))
      }, 1000)
    }
    else if (this.selectedData.value === 1) {
      var datestart = this.dateStart.toLocaleDateString();
      var dateend = this.dateEnd.toLocaleDateString();

      var dataReport = this.fdService.CreateXLSfileLive(datestart, dateend, this.selectedLpus);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.saveAsExcelFile(data, "Контроль полноты сбора данных (Текущие)");
          this.loadingExcel = false;
        }, error => console.error(error))
      }, 1000)
    }
  }
  private saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
  }
  getTagList(kodLpu: number, typeId) {
    this.router.navigate(['/taglist', kodLpu, typeId])
  }
}
interface dataType {
  name: string,
  value: number
}
interface DisplayPeriodsValue {
  tableValue: any[];
  frozenRaws: any[];
}
