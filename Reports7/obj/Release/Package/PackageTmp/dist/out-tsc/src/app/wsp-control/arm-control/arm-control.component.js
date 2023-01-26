import * as tslib_1 from "tslib";
import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { WspControlService } from '../../Services/wsp-control.service';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var ArmControlComponent = /** @class */ (function () {
    function ArmControlComponent(wspService, datePipe) {
        this.wspService = wspService;
        this.datePipe = datePipe;
        this.stateOptions = [{ label: 'Дата и Время', value: 'off' }, { label: 'Данные за период', value: 'on' }];
    }
    ArmControlComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.isError = false;
        this.errorValue = [];
        this.loading = false;
        this.loadingExcel = false;
        this.selectedData = { name: 'Интервал из списка', value: 1 };
        this.startInterval = 0;
        this.endInterval = 0;
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
        this.dateStart = new Date();
        this.dateEnd = new Date();
        this.dateStart.setHours(this.dateEnd.getHours() - 2);
        this.loadingKs = true;
        this.loadingKc = true;
        this.loadingInterval = true;
        this.loadingObj = true;
        setTimeout(function () {
            _this.wspService.GetKSList().subscribe(function (data) {
                _this.kss = data;
                _this.selectedKS = _this.kss[0];
            }, function (error) { return console.error(error); });
            _this.loadingKs = false;
        }, 1000);
        setTimeout(function () {
            _this.wspService.GetIntervalsList().subscribe(function (data) {
                _this.intervalList = data;
                _this.selectedInterval = _this.intervalList[0];
            }, function (error) { return console.error(error); });
            _this.loadingInterval = false;
        }, 1000);
        setTimeout(function () {
            _this.wspService.GetKCList(0).subscribe(function (data) {
                _this.kcs = data;
                _this.selectedKC = _this.kcs[0];
            }, function (error) { return console.error(error); });
            _this.loadingKc = false;
        }, 1000);
        setTimeout(function () {
            _this.wspService.GetObjectTypeList().subscribe(function (data) {
                _this.objTypeList = data;
                _this.selectedObjType = _this.objTypeList[0];
                _this.loadingObj = false;
            }, function (error) { return console.error(error); });
        }, 1000);
    };
    ArmControlComponent.prototype.changeKS = function () {
        var _this = this;
        this.loadingKc = true;
        setTimeout(function () {
            _this.wspService.GetKCList(_this.selectedKS.kod_ks).subscribe(function (data) {
                _this.kcs = data;
                _this.loadingKc = false;
            });
        }, 1000);
    };
    ArmControlComponent.prototype.createReport = function () {
        var _this = this;
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
            var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
            var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
            var dataReport = this.wspService.CreateReportIntervalsManualTags(datestart, dateend, this.selectedKC.kod_kc, this.selectedKS.kod_ks, this.selectedObjType.idTagType, this.startInterval, this.endInterval);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.tableValue = data;
                    _this.errorValue = _this.tableValue.filter(function (u) { return u.isError == true; });
                    if (_this.errorValue.length > 0) {
                        _this.errorMsg = _this.errorValue[0].errorMessage;
                        _this.isError = true;
                    }
                    _this.loading = false;
                }, function (error) { return console.error(error); });
            }, 1000);
            //this.wspService.CreateReportIntervalsManualTags(datestart, dateend, this.selectedKC.kod_kc, this.selectedKS.kod_ks, this.selectedObjType.idTagType, this.startInterval, this.endInterval).subscribe(data => {
            //  this.tableValue = data
            //}, error => console.error(error));
        }
        else if (this.selectedData.value === 2 && this.endInterval > this.startInterval) {
            var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
            var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
            var dataReport = this.wspService.CreateReportIntervalsManualTags(datestart, dateend, this.selectedKC.kod_kc, this.selectedKS.kod_ks, this.selectedObjType.idTagType, this.startInterval, this.endInterval);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.tableValue = data;
                    _this.errorValue = _this.tableValue.filter(function (u) { return u.isError == true; });
                    if (_this.errorValue.length > 0) {
                        _this.errorMsg = _this.errorValue[0].errorMessage;
                        _this.isError = true;
                    }
                    _this.loading = false;
                }, function (error) { return console.error(error); });
            }, 1000);
            //this.wspService.CreateReportIntervalsManualTags(datestart, dateend, this.selectedKC.kod_kc, this.selectedKS.kod_ks, this.selectedObjType.idTagType, this.startInterval, this.endInterval).subscribe(data => {
            //  this.tableValue = data
            //}, error => console.error(error));
        }
    };
    ArmControlComponent.prototype.createExcelReport = function () {
        var _this = this;
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
            var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
            var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
            var dataReport = this.wspService.CreateXLSfileManualTags(datestart, dateend, this.selectedKC.kod_kc, this.selectedKS.kod_ks, this.selectedObjType.idTagType, this.startInterval, this.endInterval);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Контроль ручного ввода");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
        else if (this.selectedData.value === 2 && this.endInterval > this.startInterval) {
            var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
            var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
            var dataReport = this.wspService.CreateXLSfileManualTags(datestart, dateend, this.selectedKC.kod_kc, this.selectedKS.kod_ks, this.selectedObjType.idTagType, this.startInterval, this.endInterval);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Контроль ручного ввода");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
    };
    ArmControlComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    ArmControlComponent.prototype.clearFilters = function () {
        this.startInterval = 0;
        this.endInterval = 0;
        this.selectedKS = this.kss[0];
        this.selectedKC = this.kcs[0];
        this.selectedObjType = this.objTypeList[0];
        this.selectedInterval = this.intervalList[0];
        this.selectedData = { name: 'Интервал из списка', value: 1 };
    };
    ArmControlComponent = tslib_1.__decorate([
        Component({
            selector: 'app-arm-control',
            templateUrl: './arm-control.component.html',
            styleUrls: ['./arm-control.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [WspControlService, DatePipe])
    ], ArmControlComponent);
    return ArmControlComponent;
}());
export { ArmControlComponent };
//# sourceMappingURL=arm-control.component.js.map