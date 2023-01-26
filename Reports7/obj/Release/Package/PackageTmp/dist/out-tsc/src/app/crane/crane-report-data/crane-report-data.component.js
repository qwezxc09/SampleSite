import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { CraneService } from '../../services/crane.service';
import { DatePipe } from '@angular/common';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var CraneReportDataComponent = /** @class */ (function () {
    function CraneReportDataComponent(craneService, datePipe) {
        this.craneService = craneService;
        this.datePipe = datePipe;
    }
    CraneReportDataComponent.prototype.ngOnInit = function () {
        var _this = this;
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
        this.isError = false;
        this.showCraneFlag = false;
        this.filterUseFlag = true;
        this.errorValue = [];
        this.tableValue = [];
        this.tableValueAll = [];
        this.tableValueRearrange = [];
        this.loading = false;
        this.loadingExcel = false;
        this.startInterval = 0;
        this.endInterval = 0;
        this.lpus = [];
        this.kps = [];
        this.dateStart = new Date();
        this.dateEnd = new Date();
        this.dateStart.setDate(this.dateEnd.getDate() - 1);
        this.loadingKp = true;
        this.loadingLpu = true;
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
    CraneReportDataComponent.prototype.createReport = function () {
        var _this = this;
        this.loading = true;
        this.showCraneFlag = false;
        if (this.selectedLpu.NsiValue == "Все ЛПУ")
            this.filterUseFlag = false;
        else
            this.filterUseFlag = true;
        var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
        var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
        var dataReport = this.craneService.CreateCraneDataReport(datestart, dateend, this.selectedLpu.NsiValue, this.selectedKp.NsiValue);
        setTimeout(function () {
            dataReport.subscribe(function (data) {
                _this.tableValue = data;
                _this.tableValueAll = data;
                _this.tableValueRearrange = _this.tableValue.filter(function (u) { return u.isNoValue == false; });
                _this.errorValue = _this.tableValue.filter(function (u) { return u.isError == true; });
                if (_this.errorValue.length > 0) {
                    _this.errorMsg = _this.errorValue[0].errorMessage;
                    _this.isError = true;
                }
                _this.loading = false;
            }, function (error) { return console.error(error); });
        }, 1000);
    };
    CraneReportDataComponent.prototype.clearFilters = function () {
        this.selectedKp = this.kps[0];
        this.selectedLpu = this.lpus[0];
        this.dateStart = new Date();
        this.dateEnd = new Date();
        this.dateStart.setDate(this.dateEnd.getDate() - 1);
    };
    CraneReportDataComponent.prototype.changeLPU = function () {
        var _this = this;
        this.loadingKp = true;
        setTimeout(function () {
            _this.craneService.GetKPList(_this.selectedLpu.NsiValue).subscribe(function (data) {
                _this.kps = data;
                _this.loadingKp = false;
            });
        }, 1000);
    };
    CraneReportDataComponent.prototype.showOnlyRearrangedCranes = function () {
        this.showCraneFlag = true;
        this.tableValue = this.tableValueRearrange;
    };
    CraneReportDataComponent.prototype.showAllCranes = function () {
        this.showCraneFlag = false;
        this.tableValue = this.tableValueAll;
    };
    CraneReportDataComponent.prototype.createExcelReport = function () {
        var _this = this;
        this.loadingExcel = true;
        var datestart = this.dateStart.toLocaleDateString();
        var dateend = this.dateEnd.toLocaleDateString();
        var dataReport = this.craneService.CreateXLSfile(datestart, dateend, this.selectedLpu.NsiValue, this.selectedKp.NsiValue, !this.showCraneFlag);
        setTimeout(function () {
            dataReport.subscribe(function (data) {
                _this.saveAsExcelFile(data, "Контроль перестановки кранов");
                _this.loadingExcel = false;
            }, function (error) { return console.error(error); });
        }, 1000);
    };
    CraneReportDataComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    CraneReportDataComponent = tslib_1.__decorate([
        Component({
            selector: 'app-crane-report-data',
            templateUrl: './crane-report-data.component.html',
            styleUrls: ['./crane-report-data.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [CraneService, DatePipe])
    ], CraneReportDataComponent);
    return CraneReportDataComponent;
}());
export { CraneReportDataComponent };
//# sourceMappingURL=crane-report-data.component.js.map