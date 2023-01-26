import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TagListService } from '../../Services/tag-list.service';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var TagListComponent = /** @class */ (function () {
    function TagListComponent(route, tagListService) {
        this.route = route;
        this.tagListService = tagListService;
    }
    TagListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.params = params;
            console.log(params);
        });
        this.loading = true;
        this.isError = false;
        if (+this.params.typeData > 1) {
            this.isLive = false;
        }
        else {
            this.isLive = true;
        }
        this.errorValue = [];
        this.tagListService.GetLpuList().subscribe(function (data) {
            _this.lpus = data;
            _this.selectedLpu = _this.lpus.filter(function (p) { return p.kod_lpu == +_this.params.kodLpu; })[0];
        }, function (error) { return console.error(error); });
        this.tagListService.GetQualityList().subscribe(function (data) {
            _this.qualityTypeList = data;
            _this.selectedQualityType = _this.qualityTypeList.filter(function (p) { return p.type_id == +_this.params.typeId; })[0];
        }, function (error) { return console.error(error); });
        this.loadingExcel = false;
        if (+this.params.typeData > 1) {
            var dataReport = this.tagListService.CreateReportPeriodTagList(+this.params.kodLpu, +this.params.typeId, this.params.stDate, this.params.endDt, +this.params.typeData);
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
        else {
            var dataReport = this.tagListService.CreateReportTagList(+this.params.kodLpu, +this.params.typeId);
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
    TagListComponent.prototype.createReport = function () {
        var _this = this;
        this.loading = true;
        console.log(this.params);
        if (+this.params.typeData > 1) {
            var dataReport = this.tagListService.CreateReportPeriodTagList(this.selectedLpu.kod_lpu, this.selectedQualityType.type_id, this.params.stDate, this.params.endDt, +this.params.typeData);
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
        else {
            var dataReport = this.tagListService.CreateReportTagList(this.selectedLpu.kod_lpu, this.selectedQualityType.type_id);
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
    TagListComponent.prototype.createExcelReport = function () {
        var _this = this;
        this.loadingExcel = true;
        if (+this.params.typeData > 1) {
            var dataExcel = this.tagListService.CreateXLSfilePeriod(this.selectedLpu.kod_lpu, this.selectedQualityType.type_id, this.params.stDate, this.params.endDt, +this.params.typeData);
            setTimeout(function () {
                dataExcel.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Список Тегов (период)");
                    _this.loadingExcel = false;
                });
            }, 1000);
        }
        else {
            var dataExcel = this.tagListService.CreateXLSfile(this.selectedLpu.kod_lpu, this.selectedQualityType.type_id);
            setTimeout(function () {
                dataExcel.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Список Тегов");
                    _this.loadingExcel = false;
                });
            }, 1000);
        }
    };
    TagListComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    TagListComponent = tslib_1.__decorate([
        Component({
            selector: 'app-tag-list',
            templateUrl: './tag-list.component.html',
            styleUrls: ['./tag-list.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [ActivatedRoute,
            TagListService])
    ], TagListComponent);
    return TagListComponent;
}());
export { TagListComponent };
//# sourceMappingURL=tag-list.component.js.map