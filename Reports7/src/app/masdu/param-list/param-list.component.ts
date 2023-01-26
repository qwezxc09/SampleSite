import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ParamListService } from '../../Services/param-list.service';
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Component({
  selector: 'app-param-list',
  templateUrl: './param-list.component.html',
  styleUrls: ['./param-list.component.css']
})
export class ParamListComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private paramListService: ParamListService
  ) { }
  loadingExcel: boolean;
  loading: boolean;

  params: Params;
  tableValue: any;


  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.params = params;
      console.log(params);
    })
    this.loadingExcel = false;
    this.loading = true;
    var dataReport = this.paramListService.CreateReportParamList(this.params.session, this.params.lpuTitle, +this.params.errId, this.params.date);
    setTimeout(() => {
      dataReport.subscribe(data => {
        this.tableValue = data
        this.loading = false;
      }, error => console.error(error))
    }, 1000)

  }
  createExcelReport() {
    this.loadingExcel = true;

    var dataExcel = this.paramListService.CreateXLSfile(this.params.session, this.params.lpuTitle, +this.params.errId, this.params.date);
    setTimeout(() => {
      dataExcel.subscribe(data => {
        this.saveAsExcelFile(data, "Cписок параметров");
        this.loadingExcel = false;
      });
    }, 1000);
  }
  private saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
  }

}
