import * as tslib_1 from "tslib";
import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { WspControlService } from '../../Services/wsp-control.service';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var LpuControlComponent = /** @class */ (function () {
    function LpuControlComponent(wspService, datePipe) {
        this.wspService = wspService;
        this.datePipe = datePipe;
    }
    LpuControlComponent.prototype.ngOnInit = function () {
        var _this = this;
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
        this.dateStart.setHours(this.dateEnd.getHours() - 2);
        this.loadingInterval = true;
        this.loadingLpu = true;
        setTimeout(function () {
            _this.wspService.GetLpuList().subscribe(function (data) {
                _this.lpus = data;
                _this.selectedLpu = _this.lpus[0];
            }, function (error) { return console.error(error); });
            _this.loadingLpu = false;
        }, 1000);
        setTimeout(function () {
            _this.wspService.GetIntervalsList().subscribe(function (data) {
                _this.intervalList = data;
                _this.selectedInterval = _this.intervalList[0];
            }, function (error) { return console.error(error); });
            _this.loadingInterval = false;
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
        //console.log(this.ru)
    };
    LpuControlComponent.prototype.createReport = function () {
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
            var dataReport = this.wspService.CreateReportIntervalsLPU(datestart, dateend, this.selectedLpu.kod_lpu, this.startInterval, this.endInterval);
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
        }
        else if (this.selectedData.value === 2 && this.endInterval > this.startInterval) {
            var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
            var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
            var dataReport = this.wspService.CreateReportIntervalsLPU(datestart, dateend, this.selectedLpu.kod_lpu, this.startInterval, this.endInterval);
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
        }
    };
    LpuControlComponent.prototype.createExcelReport = function () {
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
            var dataReport = this.wspService.CreateXLSfileLPU(datestart, dateend, this.selectedLpu.kod_lpu, this.startInterval, this.endInterval);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Контроль передачи данных ЛПУ");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
        else if (this.selectedData.value === 2 && this.endInterval > this.startInterval) {
            var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
            var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
            var dataReport = this.wspService.CreateXLSfileLPU(datestart, dateend, this.selectedLpu.kod_lpu, this.startInterval, this.endInterval);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Контроль передачи данных ЛПУ");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
            }, 1000);
        }
    };
    LpuControlComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    LpuControlComponent.prototype.clearFilters = function () {
        this.startInterval = 0;
        this.endInterval = 0;
        this.selectedLpu = this.lpus[0];
        this.selectedInterval = this.intervalList[0];
        this.selectedData = { name: 'Интервал из списка', value: 1 };
    };
    LpuControlComponent = tslib_1.__decorate([
        Component({
            selector: 'app-lpu-control',
            templateUrl: './lpu-control.component.html',
            styleUrls: ['./lpu-control.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [WspControlService, DatePipe])
    ], LpuControlComponent);
    return LpuControlComponent;
}());
export { LpuControlComponent };
//# sourceMappingURL=lpu-control.component.js.map