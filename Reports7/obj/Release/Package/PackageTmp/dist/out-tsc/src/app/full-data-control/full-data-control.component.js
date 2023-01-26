import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FullDataControlService } from '../Services/full-data-control.service';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var FullDataControlComponent = /** @class */ (function () {
    function FullDataControlComponent(fdService, router) {
        this.fdService = fdService;
        this.router = router;
        this.value1 = "off";
    }
    FullDataControlComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.isError = false;
        this.serverValue = { tableValue: [], frozenRaws: [] };
        this.dateStart = new Date();
        this.dateEnd = new Date();
        this.dateStart.setHours(this.dateEnd.getHours() - 2);
        this.loading = false;
        this.selectedLpus = [];
        this.errorValue = [];
        this.lpus = [];
        this.itogFooter = {};
        //this.tableValue = [];
        this.loadingButton = true;
        this.loadingExcel = false;
        setTimeout(function () {
            _this.fdService.GetLpuList().subscribe(function (data) {
                _this.lpus = data;
                _this.loadingButton = false;
            }, function (error) { return console.error(error); });
        }, 1000);
        console.log(this.selectedLpus);
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
    };
    FullDataControlComponent.prototype.getData = function () {
        var _this = this;
        this.loading = true;
        if (this.selectedData.value === 3) {
            var datestart = this.dateStart.toLocaleDateString();
            var dateend = this.dateEnd.toLocaleDateString();
            var dataReport = this.fdService.CreateReportPeriod(datestart, dateend, this.selectedLpus);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.serverValue = data;
                    _this.itogFooter = _this.serverValue.frozenRaws[0];
                    _this.errorValue = _this.serverValue.tableValue.filter(function (u) { return u.isError == true; });
                    if (_this.errorValue.length > 0) {
                        _this.errorMsg = _this.errorValue[0].errorMessage;
                        _this.isError = true;
                    }
                    _this.loading = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
        else if (this.selectedData.value === 2) {
            var datestart = this.dateStart.toLocaleDateString();
            var dateend = this.dateEnd.toLocaleDateString();
            var dataReport = this.fdService.CreateReportDay(datestart, dateend, this.selectedLpus);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.serverValue = data;
                    _this.itogFooter = _this.serverValue.frozenRaws[0];
                    _this.errorValue = _this.serverValue.tableValue.filter(function (u) { return u.isError == true; });
                    if (_this.errorValue.length > 0) {
                        _this.errorMsg = _this.errorValue[0].errorMessage;
                        _this.isError = true;
                    }
                    _this.loading = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
        else if (this.selectedData.value === 1) {
            //var datestart = this.dateStart.toLocaleDateString();
            //var dateend = this.dateEnd.toLocaleDateString();
            var dataReport = this.fdService.CreateReportLive(this.selectedLpus);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.serverValue = data;
                    _this.itogFooter = _this.serverValue.frozenRaws[0];
                    _this.errorValue = _this.serverValue.tableValue.filter(function (u) { return u.isError == true; });
                    if (_this.errorValue.length > 0) {
                        _this.errorMsg = _this.errorValue[0].errorMessage;
                        _this.isError = true;
                    }
                    _this.loading = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
    };
    FullDataControlComponent.prototype.createExcelReport = function () {
        var _this = this;
        this.loadingExcel = true;
        if (this.selectedData.value === 3) {
            var datestart = this.dateStart.toLocaleDateString();
            var dateend = this.dateEnd.toLocaleDateString();
            var dataReport = this.fdService.CreateXLSfilePeriod(datestart, dateend, this.selectedLpus);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Контроль полноты сбора данных (Период)");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
        else if (this.selectedData.value === 2) {
            var datestart = this.dateStart.toLocaleDateString();
            var dateend = this.dateEnd.toLocaleDateString();
            var dataReport = this.fdService.CreateXLSfileDay(datestart, dateend, this.selectedLpus);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Контроль полноты сбора данных (Сутки)");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
        else if (this.selectedData.value === 1) {
            var datestart = this.dateStart.toLocaleDateString();
            var dateend = this.dateEnd.toLocaleDateString();
            var dataReport = this.fdService.CreateXLSfileLive(datestart, dateend, this.selectedLpus);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Контроль полноты сбора данных (Текущие)");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
    };
    FullDataControlComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    FullDataControlComponent.prototype.getTagList = function (kodLpu, typeId) {
        this.router.navigate(['/taglist', kodLpu, typeId]);
    };
    FullDataControlComponent = tslib_1.__decorate([
        Component({
            selector: 'app-full-data-control',
            templateUrl: './full-data-control.component.html',
            styleUrls: ['./full-data-control.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [FullDataControlService, Router])
    ], FullDataControlComponent);
    return FullDataControlComponent;
}());
export { FullDataControlComponent };
//# sourceMappingURL=full-data-control.component.js.map