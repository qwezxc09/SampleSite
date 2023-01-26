import { Component, OnInit } from '@angular/core';
import { error } from 'protractor';
import { KS_NSI, Level_DTO, Lpu_NSI, Type_DTO } from '../../Model/Models';
import { AutoSystemService } from '../../Services/auto-system.service';
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';

@Component({
  selector: 'app-parameters',
  templateUrl: './parameters.component.html',
  styleUrls: ['./parameters.component.css']
})
export class ParametersComponent implements OnInit {

  isError: boolean;
  errorMsg: string;
  errorValue: any[];

  serverValue: DisplayPeriodsValue;
  itogFooter: any;

  ru: any;
  locale: any;

  loadingExcel: boolean;
  loading: boolean;
  loadingKs: boolean;
  loadingLpu: boolean;
  loadingLevel: boolean;
  loadingType: boolean;

  stateOptions: any[];
  tableValue: any;

  dateStart: Date;
  dateEnd: Date;

  kss: KS_NSI[];
  selectedKS: KS_NSI;

  lpus: Lpu_NSI[];
  selectedLpu: Lpu_NSI;

  levels: Level_DTO[];
  selectedLevel: Level_DTO;

  types: Type_DTO[];
  selectedType: Type_DTO;

  startInterval: number;
  endInterval: number;

  localizations: any;

  constructor(private autoSystemService: AutoSystemService) {
    this.stateOptions = [{ label: 'Дата и Время', value: 'off' }, { label: 'Данные за период', value: 'on' }];
  }
  ngOnInit(): void {
    this.isError = false;
    this.errorValue = [];
    this.loadingExcel = false;
    this.loading = false;
    this.loadingKs = true;
    this.serverValue = { tableValue: [], frozenRaws: [] };
    this.itogFooter = {};
    this.loadingLevel = true;
    this.loadingLpu = true;
    this.loadingType = true;
    setTimeout(() => {
      this.autoSystemService.GetKSList().subscribe(data => {
        this.kss = data;
        this.selectedKS = this.kss[0];
        this.loadingKs = false;
      });
    }, 1000)
    setTimeout(() => {
      this.autoSystemService.GetLpuList().subscribe(data => {
        this.lpus = data;
        this.selectedLpu = this.lpus[0];
        this.loadingLpu = false;
      });
    }, 1000)
    setTimeout(() => {
      this.autoSystemService.GetLevelList().subscribe(data => {
        this.levels = data;
        this.selectedLevel = this.levels[0];
        this.loadingLevel = false;
      });
    }, 1000)
    setTimeout(() => {
      this.autoSystemService.GetTypeList().subscribe(data => {
        this.types = data;
        this.selectedType = this.types[0];
        this.loadingType = false;
      });
    }, 1000)




  }
  createReport() {
    this.loading = true;
    var dataReport = this.autoSystemService.CreateTelemehanicaReportdata(this.selectedLpu.kod_lpu, this.selectedKS.kod_ks, this.selectedLevel.level_id, this.selectedType.type_id);
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
      })
    }, 1000);
  }
  createExcelReport() {
    this.loadingExcel = true;
    var dataExcel = this.autoSystemService.CreateXLSfile(this.selectedLpu.kod_lpu, this.selectedKS.kod_ks, this.selectedLevel.level_id, this.selectedType.type_id);
    setTimeout(() => {
      dataExcel.subscribe(data => {
        this.saveAsExcelFile(data, "Системы автоматики (параметры)");
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
  clearFilters() {
    this.selectedKS = this.kss[0];
    this.selectedLpu = this.lpus[0];
    this.selectedLevel = this.levels[0];
    this.selectedType = this.types[0];
  }

}
interface DisplayPeriodsValue {
  tableValue: any[];
  frozenRaws: any[];
}
