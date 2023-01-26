import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { Interval_NSI, Lpu_NSI } from '../../Model/Models';
import { WspControlService } from '../../Services/wsp-control.service';
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Component({
  selector: 'app-lpu-control',
  templateUrl: './lpu-control.component.html',
  styleUrls: ['./lpu-control.component.css']
})
export class LpuControlComponent implements OnInit {
  isError: boolean;
  errorMsg: string;
  errorValue: any[];
  ru: any;
  locale: any;

  loading: boolean;
  loadingExcel: boolean;
  loadingLpu: boolean;
  loadingInterval: boolean;

  stateOptions: any[];
  tableValue: any;

  dateStart: Date;
  dateEnd: Date;

  lpus: Lpu_NSI[];
  selectedLpu: Lpu_NSI;

  intervalList: Interval_NSI[];
  selectedInterval: Interval_NSI;

  startInterval: number;
  endInterval: number;

  localizations: any;

  constructor(public wspService: WspControlService, private datePipe: DatePipe) {

  }
  dataTypes: dataType[];
  selectedData: dataType;

  ngOnInit(): void {
    this.isError = false;
    this.errorValue = [];
    this.loading = false;
    this.loadingExcel = false;
    this.selectedData = { name: 'Интервал из списка', value: 1 };
    this.startInterval = 0;
    this.endInterval = 0;
    this.lpus = [];
    this.intervalList = [];

    this.dateStart = new Date();
    this.dateEnd = new Date();
    this.dateStart.setHours(this.dateEnd.getHours() - 2)
    this.loadingInterval = true;
    this.loadingLpu = true;
    setTimeout(() => {
      this.wspService.GetLpuList().subscribe(data => {
        this.lpus = data;
        this.selectedLpu = this.lpus[0];
      }, error => console.error(error));
      this.loadingLpu = false;
    }, 1000);
    setTimeout(() => {
      this.wspService.GetIntervalsList().subscribe(data => {
        this.intervalList = data;
        this.selectedInterval = this.intervalList[0];
      }, error => console.error(error));
      this.loadingInterval = false;
    }, 1000);





    this.dataTypes = [
      { name: 'Интервал из списка', value: 1 },
      { name: 'Интервал вручную', value: 2 },
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

  createReport() {
    this.loading = true;
    if (this.selectedData.value === 1) {
      switch (this.selectedInterval.interval_id) {
        case 0: {
          this.startInterval = 0;
          this.endInterval = 0;
          break;
        }
        case 1: {
          this.startInterval = 0;
          this.endInterval = 60;
          break;
        }
        case 2: {
          this.startInterval = 60;
          this.endInterval = 3600;
          break;
        }
        case 3: {
          this.startInterval = 3600;
          this.endInterval = 7200;
          break;
        }
        case 4: {
          this.startInterval = 600;
          this.endInterval = 0;
          break;
        }
        case 5: {
          this.startInterval = 1800;
          this.endInterval = 0;
          break;
        }
        case 6: {
          this.startInterval = 3600;
          this.endInterval = 0;
          break;
        }
        case 6: {
          this.startInterval = 7200;
          this.endInterval = 0;
          break;
        }
      }
      var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss')
      var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss')

      var dataReport = this.wspService.CreateReportIntervalsLPU(datestart, dateend, this.selectedLpu.kod_lpu, this.startInterval, this.endInterval);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.tableValue = data;
          this.errorValue = this.tableValue.filter(u => u.isError == true);
          if (this.errorValue.length > 0) {
            this.errorMsg = this.errorValue[0].errorMessage;
            this.isError = true;
          }
          this.loading = false;
        }, error => console.error(error))
      }, 1000)
    }
    else if (this.selectedData.value === 2 && this.endInterval > this.startInterval) {
      var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss')
      var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss')

      var dataReport = this.wspService.CreateReportIntervalsLPU(datestart, dateend, this.selectedLpu.kod_lpu, this.startInterval, this.endInterval);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.tableValue = data;
          this.errorValue = this.tableValue.filter(u => u.isError == true);
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
    if (this.selectedData.value === 1) {
      switch (this.selectedInterval.interval_id) {
        case 0: {
          this.startInterval = 0;
          this.endInterval = 0;
          break;
        }
        case 1: {
          this.startInterval = 0;
          this.endInterval = 60;
          break;
        }
        case 2: {
          this.startInterval = 60;
          this.endInterval = 3600;
          break;
        }
        case 3: {
          this.startInterval = 3600;
          this.endInterval = 7200;
          break;
        }
        case 4: {
          this.startInterval = 600;
          this.endInterval = 0;
          break;
        }
        case 5: {
          this.startInterval = 1800;
          this.endInterval = 0;
          break;
        }
        case 6: {
          this.startInterval = 3600;
          this.endInterval = 0;
          break;
        }
        case 6: {
          this.startInterval = 7200;
          this.endInterval = 0;
          break;
        }
      }
      var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss')
      var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss')

      var dataReport = this.wspService.CreateXLSfileLPU(datestart, dateend, this.selectedLpu.kod_lpu, this.startInterval, this.endInterval);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.saveAsExcelFile(data, "Контроль передачи данных ЛПУ");
          this.loadingExcel = false;
        }, error => console.error(error))
      }, 1000)
    }
    else if (this.selectedData.value === 2 && this.endInterval > this.startInterval) {

      var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss')
      var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss')

      var dataReport = this.wspService.CreateXLSfileLPU(datestart, dateend, this.selectedLpu.kod_lpu, this.startInterval, this.endInterval);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.saveAsExcelFile(data, "Контроль передачи данных ЛПУ");
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
  clearFilters() {
    this.startInterval = 0;
    this.endInterval = 0;
    this.selectedLpu = this.lpus[0];
    this.selectedInterval = this.intervalList[0];
    this.selectedData = { name: 'Интервал из списка', value: 1 };
  }
}
interface dataType {
  name: string,
  value: number
}
