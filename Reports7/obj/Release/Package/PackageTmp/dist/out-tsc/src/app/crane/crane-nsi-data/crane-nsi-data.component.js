import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { CraneService } from '../../services/crane.service';
import { DatePipe } from '@angular/common';
import { ConfirmationService } from 'primeng-lts/api';
var CraneNsiDataComponent = /** @class */ (function () {
    function CraneNsiDataComponent(craneService, datePipe, confirmationService) {
        this.craneService = craneService;
        this.datePipe = datePipe;
        this.confirmationService = confirmationService;
        this.msgs = [];
    }
    CraneNsiDataComponent.prototype.ngOnInit = function () {
        var _this = this;
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
        setTimeout(function () {
            _this.craneService.GetLpuList().subscribe(function (data) {
                _this.lpus = data;
                _this.selectedLpu = _this.lpus[0];
                _this.loadingLpu = false;
            }, function (error) { return console.error(error); });
        }, 1000);
        setTimeout(function () {
            _this.craneService.GetKPList("").subscribe(function (data) {
                _this.kps = data;
                _this.selectedKp = _this.kps[0];
                _this.loadingKp = false;
            }, function (error) { return console.error(error); });
        }, 1000);
    };
    CraneNsiDataComponent.prototype.getNSIData = function () {
        var _this = this;
        this.loading = true;
        var dataReport = this.craneService.GetCraneNSIData(this.selectedLpu.NsiValue, this.selectedKp.NsiValue);
        setTimeout(function () {
            dataReport.subscribe(function (data) {
                _this.nsiList = data;
                _this.errorValue = _this.nsiList.filter(function (u) { return u.isError == true; });
                if (_this.errorValue.length > 0) {
                    _this.errorMsg = _this.errorValue[0].errorMessage;
                    _this.isError = true;
                }
                _this.loading = false;
            }, function (error) { return console.error(error); });
        }, 1000);
    };
    CraneNsiDataComponent.prototype.clearFilters = function () {
        this.selectedKp = this.kps[0];
        this.selectedLpu = this.lpus[0];
    };
    CraneNsiDataComponent.prototype.changeLPU = function () {
        var _this = this;
        this.loadingKp = true;
        setTimeout(function () {
            _this.craneService.GetKPList(_this.selectedLpu.NsiValue).subscribe(function (data) {
                _this.kps = data;
                _this.loadingKp = false;
            });
        }, 1000);
    };
    CraneNsiDataComponent.prototype.changeNsiItem = function () {
        this.selectedItem.Changed = true;
        //console.log(this.selectedItem);
        console.log(this.nsiList);
    };
    CraneNsiDataComponent.prototype.removeNsiItem = function () {
        this.selectedItem.Deleted = true;
    };
    CraneNsiDataComponent.prototype.addNsiItem = function () {
        var id = this.nsiList[this.nsiList.length - 1].Id + 1;
        var item = {
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
    };
    CraneNsiDataComponent.prototype.saveNsiData = function () {
        var _this = this;
        this.displaySaveAccept = false;
        this.loadingSave = true;
        var authorized = false;
        this.craneService.CheckUserData(this.userName, this.password).subscribe(function (data) {
            authorized = data;
            if (authorized) {
                setTimeout(function () {
                    _this.craneService.SaveCraneNSIData(_this.nsiList.filter(function (u) { return u.Changed == true; })).subscribe(function (data) {
                        _this.saveConfirm = data;
                        _this.loadingSave = false;
                        if (_this.saveConfirm) {
                            _this.userName = null;
                            _this.password = null;
                            _this.getNSIData();
                            _this.showSuccess();
                        }
                        else {
                            _this.showError('Сохранение не выполнено');
                        }
                    });
                }, 1000);
            }
            else {
                _this.showError('Неверный логин или пароль');
                _this.loadingSave = false;
                _this.userName = null;
                _this.password = null;
            }
        });
    };
    CraneNsiDataComponent.prototype.displaySaveConfirm = function () {
        this.displaySaveAccept = true;
    };
    CraneNsiDataComponent.prototype.cancelSave = function () {
        this.displaySaveAccept = false;
    };
    CraneNsiDataComponent.prototype.confirmDelete = function () {
        var _this = this;
        this.confirmationService.confirm({
            message: 'Вы уверены, что хотите далить запись?',
            header: 'Подтверждение удаления',
            icon: 'pi pi-exclamation-triangle',
            accept: function () {
                _this.removeNsiItem();
            },
            reject: function () {
            }
        });
    };
    CraneNsiDataComponent.prototype.showSuccess = function () {
        this.msgs = [];
        this.msgs.push({ severity: 'success', summary: 'Успешно', detail: 'Сохранение выполнено' });
    };
    CraneNsiDataComponent.prototype.showError = function (msg) {
        this.msgs = [];
        this.msgs.push({ severity: 'error', summary: 'Ошибка', detail: msg });
    };
    CraneNsiDataComponent = tslib_1.__decorate([
        Component({
            selector: 'app-crane-nsi-data',
            templateUrl: './crane-nsi-data.component.html',
            styleUrls: ['./crane-nsi-data.component.css'],
            providers: [ConfirmationService]
        }),
        tslib_1.__metadata("design:paramtypes", [CraneService, DatePipe, ConfirmationService])
    ], CraneNsiDataComponent);
    return CraneNsiDataComponent;
}());
export { CraneNsiDataComponent };
//# sourceMappingURL=crane-nsi-data.component.js.map