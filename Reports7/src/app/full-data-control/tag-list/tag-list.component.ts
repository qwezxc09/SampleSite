import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Lpu_NSI, QualityTypes_DTO } from '../../Model/Models';
import { TagListService } from '../../Services/tag-list.service';
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Component({
  selector: 'app-tag-list',
  templateUrl: './tag-list.component.html',
  styleUrls: ['./tag-list.component.css']
})
export class TagListComponent implements OnInit {

  isError: boolean;
  errorMsg: string;
  errorValue: any[];
  isLive: boolean;
  lpus: Lpu_NSI[];
  selectedLpu: Lpu_NSI;

  qualityTypeList: QualityTypes_DTO[];
  selectedQualityType: QualityTypes_DTO;

  loadingExcel: boolean;
  loading: boolean;
  params: Params;

  tableValue: any;

  constructor(
    private route: ActivatedRoute,
    private tagListService: TagListService,
  ) { }



  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.params = params;
      console.log(params);
    })
    this.loading = true;
    this.isError = false;
    if (+this.params.typeData > 1) {
      this.isLive = false;
    }
    else {
      this.isLive = true;
    }
    this.errorValue = [];
    this.tagListService.GetLpuList().subscribe(data => {
      this.lpus = data;
      this.selectedLpu = this.lpus.filter(p => p.kod_lpu == +this.params.kodLpu)[0];
    }, error => console.error(error));
    this.tagListService.GetQualityList().subscribe(data => {
      this.qualityTypeList = data;
      this.selectedQualityType = this.qualityTypeList.filter(p => p.type_id == +this.params.typeId)[0];
    }, error => console.error(error));
    this.loadingExcel = false;
    if (+this.params.typeData > 1) {
      var dataReport = this.tagListService.CreateReportPeriodTagList(+this.params.kodLpu, +this.params.typeId, this.params.stDate, this.params.endDt, +this.params.typeData);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.tableValue = data
          this.errorValue = this.tableValue.filter(u => u.isError == true);
          if (this.errorValue.length > 0) {
            this.errorMsg = this.errorValue[0].errorMessage;
            this.isError = true;
          }
          this.loading = false;
        }, error => console.error(error))
      }, 1000)
    }
    else {
      var dataReport = this.tagListService.CreateReportTagList(+this.params.kodLpu, +this.params.typeId);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.tableValue = data
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
  createReport() {
    this.loading = true;
    console.log(this.params)
    if (+this.params.typeData > 1) {
      var dataReport = this.tagListService.CreateReportPeriodTagList(this.selectedLpu.kod_lpu, this.selectedQualityType.type_id, this.params.stDate, this.params.endDt, +this.params.typeData);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.tableValue = data
          this.errorValue = this.tableValue.filter(u => u.isError == true);
          if (this.errorValue.length > 0) {
            this.errorMsg = this.errorValue[0].errorMessage;
            this.isError = true;
          }
          this.loading = false;
        }, error => console.error(error))
      }, 1000)
    }
    else {
      var dataReport = this.tagListService.CreateReportTagList(this.selectedLpu.kod_lpu, this.selectedQualityType.type_id);
      setTimeout(() => {
        dataReport.subscribe(data => {
          this.tableValue = data
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
    if (+this.params.typeData > 1) {
      var dataExcel = this.tagListService.CreateXLSfilePeriod(this.selectedLpu.kod_lpu, this.selectedQualityType.type_id, this.params.stDate, this.params.endDt, +this.params.typeData);
      setTimeout(() => {
        dataExcel.subscribe(data => {
          this.saveAsExcelFile(data, "Список Тегов (период)");
          this.loadingExcel = false;
        });
      }, 1000);
    }
    else {
      var dataExcel = this.tagListService.CreateXLSfile(this.selectedLpu.kod_lpu, this.selectedQualityType.type_id);
      setTimeout(() => {
        dataExcel.subscribe(data => {
          this.saveAsExcelFile(data, "Список Тегов");
          this.loadingExcel = false;
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
