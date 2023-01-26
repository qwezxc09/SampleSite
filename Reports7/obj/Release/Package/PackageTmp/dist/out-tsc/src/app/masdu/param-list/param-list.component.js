import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ParamListService } from '../../Services/param-list.service';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var ParamListComponent = /** @class */ (function () {
    function ParamListComponent(route, paramListService) {
        this.route = route;
        this.paramListService = paramListService;
    }
    ParamListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.params = params;
            console.log(params);
        });
        this.loadingExcel = false;
        this.loading = true;
        var dataReport = this.paramListService.CreateReportParamList(this.params.session, this.params.lpuTitle, +this.params.errId, this.params.date);
        setTimeout(function () {
            dataReport.subscribe(function (data) {
                _this.tableValue = data;
                _this.loading = false;
            }, function (error) { return console.error(error); });
        }, 1000);
    };
    ParamListComponent.prototype.createExcelReport = function () {
        var _this = this;
        this.loadingExcel = true;
        var dataExcel = this.paramListService.CreateXLSfile(this.params.session, this.params.lpuTitle, +this.params.errId, this.params.date);
        setTimeout(function () {
            dataExcel.subscribe(function (data) {
                _this.saveAsExcelFile(data, "Cписок параметров");
                _this.loadingExcel = false;
            });
        }, 1000);
    };
    ParamListComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    ParamListComponent = tslib_1.__decorate([
        Component({
            selector: 'app-param-list',
            templateUrl: './param-list.component.html',
            styleUrls: ['./param-list.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [ActivatedRoute,
            ParamListService])
    ], ParamListComponent);
    return ParamListComponent;
}());
export { ParamListComponent };
//# sourceMappingURL=param-list.component.js.map