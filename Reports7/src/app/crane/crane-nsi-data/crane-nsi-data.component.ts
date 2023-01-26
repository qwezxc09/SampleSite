import { Component, OnInit } from '@angular/core';
import { CraneService } from '../../services/crane.service';
import { DatePipe } from '@angular/common';
import { Display_NSI, ZAR_NSI_WEB } from '../../Model/Models';
import { ConfirmationService, Message } from 'primeng-lts/api';
import { ConfirmDialogModule } from 'primeng-lts/confirmdialog';

@Component({
  selector: 'app-crane-nsi-data',
  templateUrl: './crane-nsi-data.component.html',
  styleUrls: ['./crane-nsi-data.component.css'],
  providers: [ConfirmationService]
})
export class CraneNsiDataComponent implements OnInit {

  constructor(public craneService: CraneService, private datePipe: DatePipe, private confirmationService: ConfirmationService) { }

  isError: boolean;
  errorMsg: string;
  errorValue: any[];
  locale: any;
  userName: string;
  password: string;
  displaySaveAccept: boolean;
  msgs: Message[] = [];

  loading: boolean;
  loadingExcel: boolean;
  loadingLpu: boolean;
  loadingKp: boolean;
  loadingSave: boolean;
  saveConfirm: boolean;

  tableValue: any;

  lpus: Display_NSI[];
  selectedLpu: Display_NSI;

  kps: any;
  selectedKp: Display_NSI;

  selectedItem: ZAR_NSI_WEB;
  nsiList: ZAR_NSI_WEB[];


  ngOnInit() {
    this.isError = false;
    this.displaySaveAccept = false;
    this.password = null;
    this.userName = null;
    this.errorValue = [];
    this.loading = false;
    this.loadingExcel = false;
    this.loadingSave = false;
    this.lpus = [];
    this.kps = [];
    this.nsiList = [];
    this.loadingKp = true;
    this.loadingLpu = true;
    this.selectedItem = null;
    console.log(this.nsiList.length);
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
  getNSIData() {
    this.loading = true;
    var dataReport = this.craneService.GetCraneNSIData(this.selectedLpu.NsiValue, this.selectedKp.NsiValue);
    setTimeout(() => {
      dataReport.subscribe(data => {
        this.nsiList = data as ZAR_NSI_WEB[];
        this.errorValue = this.nsiList.filter(u => u.isError == true);
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
  changeNsiItem() {
    this.selectedItem.Changed = true;
    console.log(this.nsiList);
  }
  removeNsiItem() {
    this.selectedItem.Deleted = true;
  }
  addNsiItem() {
    var id = this.nsiList[this.nsiList.length - 1].Id + 1;
    var item: ZAR_NSI_WEB = {
      Added: true,
      Deleted: false,
      Changed: false,
      LPU_Name: "",
      KP_Name: "",
      kodZAR_SLTM: "",
      kodZAR_SODU: "",
      Tagname: "",
      Comment: "",
      ShortZAR_Name: "",
      LongZAR_Name: "",
      Id: id,
      isError: false,
      errorMessage: ""
    };
    this.nsiList.push(item);
  }
  saveNsiData() {
    this.displaySaveAccept = false;
    this.loadingSave = true;
    var authorized = false;
    this.craneService.CheckUserData(this.userName, this.password).subscribe(data => {
      authorized = data as boolean;
      if (authorized) {
        setTimeout(() => {
          this.craneService.SaveCraneNSIData(this.nsiList.filter(u => u.Changed == true)).subscribe(data => {
            this.saveConfirm = data as boolean;
            this.loadingSave = false;
            if (this.saveConfirm) {
              this.userName = null;
              this.password = null;
              this.getNSIData();
              this.showSuccess();
            }
            else {
              this.showError('Сохранение не выполнено');
            }
          })
        }, 1000)
      }
      else {
        this.showError('Неверный логин или пароль');
        this.loadingSave = false;
        this.userName = null;
        this.password = null;
      }
    });
  }
  displaySaveConfirm() {
    this.displaySaveAccept = true;
  }
  cancelSave() {
    this.displaySaveAccept = false;
  }
  confirmDelete() {
    this.confirmationService.confirm({
      message: 'Вы уверены, что хотите далить запись?',
      header: 'Подтверждение удаления',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.removeNsiItem();
      },
      reject: () => {

      }
    });
  }
  showSuccess() {
    this.msgs = [];
    this.msgs.push({ severity: 'success', summary: 'Успешно', detail: 'Сохранение выполнено' });
  }
  showError(msg: string) {
    this.msgs = [];
    this.msgs.push({ severity: 'error', summary: 'Ошибка', detail: msg });
  }
}
