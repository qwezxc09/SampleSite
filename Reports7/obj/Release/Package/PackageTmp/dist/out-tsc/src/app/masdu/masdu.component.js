import * as tslib_1 from "tslib";
import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { MasduService } from '../Services/masdu.service';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var MasduComponent = /** @class */ (function () {
    function MasduComponent(masduService, datePipe) {
        this.masduService = masduService;
        this.datePipe = datePipe;
    }
    MasduComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.isError = false;
        this.errorValue = [];
        this.isErrorLpu = false;
        this.errorValueLpu = [];
        this.secondTable = false;
        this.loading = false;
        this.loadingLpu = false;
        this.dataTypes = [
            { name: 'Дата и время', value: 1 },
            { name: 'Данные за период', value: 2 },
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
        this.selectedData = { name: 'Дата и время', value: 1 };
        this.dateStart = new Date();
        this.dateEnd = new Date();
        this.dateStart.setHours(this.dateEnd.getHours() - 2);
        this.loadingSession = true;
        this.loadingExcel = false;
        setTimeout(function () {
            _this.masduService.GetSessionList().subscribe(function (data) {
                _this.sessions = data;
                _this.selectedSession = _this.sessions[0];
                _this.loadingSession = false;
            }, function (error) { return console.error(error); });
        }, 1000);
    };
    MasduComponent.prototype.createReport = function () {
        var _this = this;
        this.secondTable = false;
        var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
        var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
        this.loading = true;
        if (this.selectedData.value === 1) {
            var dataReport = this.masduService.CreateReportMasdu(datestart, dateend, this.selectedSession.description);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    //console.log(data)
                    _this.tableValues = data;
                    _this.errorValue = _this.tableValues.filter(function (u) { return u.isError == true; });
                    if (_this.errorValue.length > 0) {
                        _this.errorMsg = _this.errorValue[0].errorMessage;
                        _this.isError = true;
                    }
                    _this.loading = false;
                    var dataReport1 = _this.masduService.CreateReportMasduLPU(datestart, dateend, _this.selectedSession.description);
                    _this.loadingLpu = true;
                    _this.secondTable = true;
                    //setTimeout(() => {
                    dataReport1.subscribe(function (data) {
                        _this.tableValuesLpu = data;
                        _this.errorValueLpu = _this.tableValuesLpu.filter(function (u) { return u.isError == true; });
                        if (_this.errorValueLpu.length > 0) {
                            _this.errorMsgLpu = _this.errorValueLpu[0].errorMessage;
                            _this.isErrorLpu = true;
                        }
                        _this.loadingLpu = false;
                        //if (this.tableValuesLpu.length !== 0) {
                        //  this.secondTable = true;
                        //}
                        //else
                        //  this.secondTable = false;
                    }, function (error) { return console.error(error); });
                    //  },
                }, function (error) { return console.error(error); });
            }, 1000);
        }
        else if (this.selectedData.value === 2) {
            var dataReport = this.masduService.CreateReportMasduPeriod(datestart, dateend, this.selectedSession.description);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    //console.log(data);
                    _this.tableValues = data;
                    _this.errorValue = _this.tableValues.filter(function (u) { return u.isError == true; });
                    if (_this.errorValue.length > 0) {
                        _this.errorMsg = _this.errorValue[0].errorMessage;
                        _this.isError = true;
                    }
                    _this.loading = false;
                    var dataReport1 = _this.masduService.CreateReportMasduLPUPeriod(datestart, dateend, _this.selectedSession.description);
                    _this.loadingLpu = true;
                    _this.secondTable = true;
                    //setTimeout(() => {
                    dataReport1.subscribe(function (data) {
                        //console.log(data);
                        _this.tableValuesLpu = data;
                        _this.errorValueLpu = _this.tableValuesLpu.filter(function (u) { return u.isError == true; });
                        if (_this.errorValueLpu.length > 0) {
                            console.log(_this.errorValue);
                            _this.errorMsgLpu = _this.errorValueLpu[0].errorMessage;
                            _this.isErrorLpu = true;
                        }
                        _this.loadingLpu = false;
                        //console.log(this.tableValuesLpu)
                        //if (this.tableValuesLpu.length !== 0) {
                        //  this.secondTable = true;
                        //}
                    }, function (error) { return console.error(error); });
                    //}, 1000);
                }, function (error) { return console.error(error); });
            }, 1000);
            //setTimeout(() => {
            //  dataReport1.subscribe(data => {
            //    this.tableValuesLpu = data;
            //    console.log(this.tableValuesLpu)
            //    if (this.tableValuesLpu.length !== 0) {
            //      this.secondTable = true;
            //    }
            //  }, error => console.error(error))
            //}, 1000);
        }
    };
    MasduComponent.prototype.createExcelReport = function () {
        var _this = this;
        this.loadingExcel = true;
        var datestart = this.datePipe.transform(this.dateStart, 'dd.MM.yyyy HH:mm:ss');
        var dateend = this.datePipe.transform(this.dateEnd, 'dd.MM.yyyy HH:mm:ss');
        if (this.selectedData.value === 1) {
            var dataReport = this.masduService.CreateXLSfile(datestart, dateend, this.selectedSession.description);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Список Параметров");
                    var dataReport1 = _this.masduService.CreateXLSfileLpu(datestart, dateend, _this.selectedSession.description);
                    dataReport1.subscribe(function (data) {
                        _this.saveAsExcelFile(data, "Список Параметров ЛПУ");
                        _this.loadingExcel = false;
                    }, function (error) { return console.error(error); });
                }, function (error) { return console.error(error); });
            }, 1000);
            //if (this.secondTable)
            //  var dataReport1 = this.masduService.CreateXLSfileLpu(datestart, dateend, this.selectedSession.description);
            //  setTimeout(() => {
            //    dataReport1.subscribe(data => {
            //      this.saveAsExcelFile(data, "Список Параметров ЛПУ");
            //      this.loadingExcel = false;
            //    }, error => console.error(error))
            //  }, 1000);
        }
        else if (this.selectedData.value === 2) {
            var dataReport = this.masduService.CreateXLSfilePeriod(datestart, dateend, this.selectedSession.description);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Список Параметров");
                    var dataReport1 = _this.masduService.CreateXLSfileLpuPeriod(datestart, dateend, _this.selectedSession.description);
                    dataReport1.subscribe(function (data) {
                        _this.saveAsExcelFile(data, "Список Параметров ЛПУ");
                        _this.loadingExcel = false;
                    }, function (error) { return console.error(error); });
                }, function (error) { return console.error(error); });
            }, 1000);
            //if (this.secondTable)
            //  var dataReport1 = this.masduService.CreateXLSfileLpuPeriod(datestart, dateend, this.selectedSession.description);
            //  setTimeout(() => {
            //    dataReport1.subscribe(data => {
            //      this.saveAsExcelFile(data, "Список Параметров ЛПУ");
            //      this.loadingExcel = false;
            //    }, error => console.error(error))
            //  }, 1000);
        }
    };
    MasduComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    MasduComponent = tslib_1.__decorate([
        Component({
            selector: 'app-masdu',
            templateUrl: './masdu.component.html',
            styleUrls: ['./masdu.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [MasduService, DatePipe])
    ], MasduComponent);
    return MasduComponent;
}());
export { MasduComponent };
//# sourceMappingURL=masdu.component.js.map