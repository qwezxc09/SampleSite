import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { Session_DTO } from '../Model/Models';
import { MasduService } from '../Services/masdu.service';
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';


@Component({
  selector: 'app-masdu',
  templateUrl: './masdu.component.html',
  styleUrls: ['./masdu.component.css']
})
export class MasduComponent implements OnInit {

  isError: boolean;
  errorMsg: string;
  errorValue: any[];
  isErrorLpu: boolean;
  errorMsgLpu: string;
  errorValueLpu: any[];

  loading: boolean;
  loadingLpu: boolean;
  loadingExcel: boolean;
  loadingSession: boolean;
  secondTable: boolean;
  ru: any;

  dateStart: Date;
  dateEnd: Date;

  tableValues: any;
  tableValuesLpu: any;

  sessions: Session_DTO[];
  selectedSession: Session_DTO;

  dataTypes: dataType[];
  selectedData: dataType;

  constructor(private masduService: MasduService, private datePipe: DatePipe) { }

  ngOnInit(): void {
    this.isError = false;
    this.errorValue = [];
    this.isErrorLpu = false;
    this.errorValueLpu = [];
    this.secondTable = false;
    this.loading = false;
    this.loadingLpu = false;
    this.dataTypes = [
      { name: 'Дата и время', value: 1 },
      { name: 'Данные за период', value: 2 },
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

    this.selectedData = { name: 'Дата и время', value: 1 };

    this.dateStart = new Date();
    this.dateEnd = new Date();
    this.dateStart.setHours(this.dateEnd.getHours() - 2)
    this.loadingSession = true;
    this.loadingExcel = false;
    setTimeout(() => {
      this.masduService.GetSessionList().subscribe(data => {
        this.sessions = data;
        this.selectedSession = this.sessions[0];
        this.loadingSession = false;
      }, error => console.error(error))
    }, 1000);


  }
  createReport() {
    this.secondTable = false;
    var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss')
    var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss')

    this.loading = true;

    if (this.selectedData.value === 1) {
      var dataReport = this.masduService.CreateReportMasdu(datestart, dateend, this.selectedSession.description);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.tableValues = data;
          this.errorValue = this.tableValues.filter(u => u.isError == true);
          if (this.errorValue.length > 0) {
            this.errorMsg = this.errorValue[0].errorMessage;
            this.isError = true;
          }
          this.loading = false;
          var dataReport1 = this.masduService.CreateReportMasduLPU(datestart, dateend, this.selectedSession.description);
          this.loadingLpu = true;
          this.secondTable = true;
          dataReport1.subscribe(data => {
            this.tableValuesLpu = data;
            this.errorValueLpu = this.tableValuesLpu.filter(u => u.isError == true);
            if (this.errorValueLpu.length > 0) {
              this.errorMsgLpu = this.errorValueLpu[0].errorMessage;
              this.isErrorLpu = true;
            }
            this.loadingLpu = false;
          }, error => console.error(error));
        }, error => console.error(error))
      }, 1000);

    }
    else if (this.selectedData.value === 2) {
      var dataReport = this.masduService.CreateReportMasduPeriod(datestart, dateend, this.selectedSession.description);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.tableValues = data;
          this.errorValue = this.tableValues.filter(u => u.isError == true);
          if (this.errorValue.length > 0) {
            this.errorMsg = this.errorValue[0].errorMessage;
            this.isError = true;
          }
          this.loading = false;
          var dataReport1 = this.masduService.CreateReportMasduLPUPeriod(datestart, dateend, this.selectedSession.description);
          this.loadingLpu = true;
          this.secondTable = true;
          dataReport1.subscribe(data => {
            this.tableValuesLpu = data;
            this.errorValueLpu = this.tableValuesLpu.filter(u => u.isError == true);
            if (this.errorValueLpu.length > 0) {
              console.log(this.errorValue);
              this.errorMsgLpu = this.errorValueLpu[0].errorMessage;
              this.isErrorLpu = true;
            }
            this.loadingLpu = false;
          }, error => console.error(error));
        }, error => console.error(error))
      }, 1000);
    }
  }

  createExcelReport() {
    this.loadingExcel = true;
    var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss')
    var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss')

    if (this.selectedData.value === 1) {
      var dataReport = this.masduService.CreateXLSfile(datestart, dateend, this.selectedSession.description);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.saveAsExcelFile(data, "Список Параметров");
          var dataReport1 = this.masduService.CreateXLSfileLpu(datestart, dateend, this.selectedSession.description);
          dataReport1.subscribe(data => {
            this.saveAsExcelFile(data, "Список Параметров ЛПУ");
            this.loadingExcel = false;
          }, error => console.error(error))
        }, error => console.error(error))
      }, 1000);
    }
    else if (this.selectedData.value === 2) {
      var dataReport = this.masduService.CreateXLSfilePeriod(datestart, dateend, this.selectedSession.description);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.saveAsExcelFile(data, "Список Параметров");
          var dataReport1 = this.masduService.CreateXLSfileLpuPeriod(datestart, dateend, this.selectedSession.description);
          dataReport1.subscribe(data => {
            this.saveAsExcelFile(data, "Список Параметров ЛПУ");
            this.loadingExcel = false;
          }, error => console.error(error))
        }, error => console.error(error))
      }, 1000);
    }



  }

  private saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
  }

}
interface dataType {
  name: string,
  value: number
}
