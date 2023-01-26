import { Component, OnInit } from '@angular/core';
import { AutoSystemService } from '../../Services/auto-system.service';
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';
@Component({
  selector: 'app-connected-systems',
  templateUrl: './connected-systems.component.html',
  styleUrls: ['./connected-systems.component.css']
})
export class ConnectedSystemsComponent implements OnInit {

  loading: boolean;
  loadingExcel = false;

  isError: boolean;
  errorMsg: string;
  errorValue: any[];

  dateNow: Date;
  kcCount: any[];

  dataTypes: dataType[];
  selectedData: dataType;
  constructor(private autoSystemService: AutoSystemService) { }
  tableValuesKC: any;
  tableValuesGpa: any;

  ngOnInit(): void {
    this.isError = false;
    this.errorValue = [];
    this.loading = false;
    this.loadingExcel = false;
    this.dateNow = new Date();
    this.dataTypes = [
      { name: "САУ КЦ", value: 1 },
      { name: "САУ ГПА", value: 2 }
    ];
    this.kcCount = [
      { KodKc: 1, Title: "КЦ 1" },
      { KodKc: 2, Title: "КЦ 2" },
      { KodKc: 3, Title: "КЦ 3" },
      { KodKc: 4, Title: "КЦ 4" },
      { KodKc: 5, Title: "КЦ 5" },
      { KodKc: 6, Title: "КЦ 6" },
      { KodKc: 7, Title: "КЦ 7" },
      { KodKc: 8, Title: "КЦ 8" },
      { KodKc: 9, Title: "КЦ 9" },
      { KodKc: 10, Title: "КЦ 10" },
    ];
    this.selectedData = { name: 'САУ ГПА', value: 2 };
    this.tableValuesKC = "";
  }
  createReport() {
    this.loading = true;
    var dataReport = this.autoSystemService.GetTelemehanicaGpaData();
    setTimeout(() => {
      dataReport.subscribe(data => {
        this.tableValuesGpa = data;
        this.errorValue = this.tableValuesGpa.filter(u => u.isError == true);
        if (this.errorValue.length > 0) {
          this.errorMsg = this.errorValue[0].errorMessage;
          this.isError = true;
        }
        this.loading = false;
      }, error => console.error(error)); (data => {
      });
    }, 1000);
  }
  createExcelReport() {
    this.loadingExcel = true;
    if (this.selectedData.value === 1) {
      if (this.tableValuesKC === "")
        this.autoSystemService.CreateXLSfileKC(this.selectedData.value).subscribe(data => {
          this.saveAsExcelFile(data, "Подключенные системы КЦ");
          this.loadingExcel = false;
        }, error => console.error(error))
    }
    else {
      var dataReport = this.autoSystemService.CreateXLSfileGPA(this.selectedData.value);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.saveAsExcelFile(data, "Подключенные системы ГПА");
          this.loadingExcel = false;
        }, error => console.error(error)); (data => {
        });
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
