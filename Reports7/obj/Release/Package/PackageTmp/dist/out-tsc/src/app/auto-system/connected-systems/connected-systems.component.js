import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { AutoSystemService } from '../../Services/auto-system.service';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var ConnectedSystemsComponent = /** @class */ (function () {
    function ConnectedSystemsComponent(autoSystemService) {
        this.autoSystemService = autoSystemService;
        this.loadingExcel = false;
    }
    ConnectedSystemsComponent.prototype.ngOnInit = function () {
        this.isError = false;
        this.errorValue = [];
        this.loading = false;
        this.loadingExcel = false;
        this.dateNow = new Date();
        this.dataTypes = [
            { name: "САУ КЦ", value: 1 },
            { name: "САУ ГПА", value: 2 }
        ];
        this.kcCount = [
            { KodKc: 1, Title: "КЦ 1" },
            { KodKc: 2, Title: "КЦ 2" },
            { KodKc: 3, Title: "КЦ 3" },
            { KodKc: 4, Title: "КЦ 4" },
            { KodKc: 5, Title: "КЦ 5" },
            { KodKc: 6, Title: "КЦ 6" },
            { KodKc: 7, Title: "КЦ 7" },
            { KodKc: 8, Title: "КЦ 8" },
            { KodKc: 9, Title: "КЦ 9" },
            { KodKc: 10, Title: "КЦ 10" },
        ];
        this.selectedData = { name: 'САУ ГПА', value: 2 };
        this.tableValuesKC = "";
    };
    ConnectedSystemsComponent.prototype.createReport = function () {
        var _this = this;
        this.loading = true;
        //if (this.selectedData.value === 1) {
        //  if (this.tableValuesKC === "")
        //    this.autoSystemService.GetTelemehanicaKcData().subscribe(data => {
        //      this.tableValuesKC = data;
        //    }, error => console.error(error))
        //}
        //else {
        var dataReport = this.autoSystemService.GetTelemehanicaGpaData();
        setTimeout(function () {
            dataReport.subscribe(function (data) {
                _this.tableValuesGpa = data;
                _this.errorValue = _this.tableValuesGpa.filter(function (u) { return u.isError == true; });
                if (_this.errorValue.length > 0) {
                    _this.errorMsg = _this.errorValue[0].errorMessage;
                    _this.isError = true;
                }
                _this.loading = false;
            }, function (error) { return console.error(error); });
            (function (data) {
            });
        }, 1000);
    };
    ConnectedSystemsComponent.prototype.createExcelReport = function () {
        var _this = this;
        this.loadingExcel = true;
        if (this.selectedData.value === 1) {
            if (this.tableValuesKC === "")
                this.autoSystemService.CreateXLSfileKC(this.selectedData.value).subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Подключенные системы КЦ");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
        }
        else {
            var dataReport = this.autoSystemService.CreateXLSfileGPA(this.selectedData.value);
            setTimeout(function () {
                dataReport.subscribe(function (data) {
                    _this.saveAsExcelFile(data, "Подключенные системы ГПА");
                    _this.loadingExcel = false;
                }, function (error) { return console.error(error); });
                (function (data) {
                });
            }, 1000);
        }
    };
    ConnectedSystemsComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    ConnectedSystemsComponent = tslib_1.__decorate([
        Component({
            selector: 'app-connected-systems',
            templateUrl: './connected-systems.component.html',
            styleUrls: ['./connected-systems.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [AutoSystemService])
    ], ConnectedSystemsComponent);
    return ConnectedSystemsComponent;
}());
export { ConnectedSystemsComponent };
//# sourceMappingURL=connected-systems.component.js.map