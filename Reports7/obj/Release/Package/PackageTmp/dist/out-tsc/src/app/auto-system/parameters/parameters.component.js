import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { AutoSystemService } from '../../Services/auto-system.service';
import * as FileSaver from 'file-saver';
var EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
var EXCEL_EXTENSION = '.xlsx';
var ParametersComponent = /** @class */ (function () {
    function ParametersComponent(autoSystemService) {
        this.autoSystemService = autoSystemService;
        this.stateOptions = [{ label: 'Дата и Время', value: 'off' }, { label: 'Данные за период', value: 'on' }];
    }
    ParametersComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.isError = false;
        this.errorValue = [];
        this.loadingExcel = false;
        this.loading = false;
        this.loadingKs = true;
        this.serverValue = { tableValue: [], frozenRaws: [] };
        this.itogFooter = {};
        this.loadingLevel = true;
        this.loadingLpu = true;
        this.loadingType = true;
        setTimeout(function () {
            _this.autoSystemService.GetKSList().subscribe(function (data) {
                _this.kss = data;
                _this.selectedKS = _this.kss[0];
                _this.loadingKs = false;
            });
        }, 1000);
        setTimeout(function () {
            _this.autoSystemService.GetLpuList().subscribe(function (data) {
                _this.lpus = data;
                _this.selectedLpu = _this.lpus[0];
                _this.loadingLpu = false;
            });
        }, 1000);
        setTimeout(function () {
            _this.autoSystemService.GetLevelList().subscribe(function (data) {
                _this.levels = data;
                _this.selectedLevel = _this.levels[0];
                _this.loadingLevel = false;
            });
        }, 1000);
        setTimeout(function () {
            _this.autoSystemService.GetTypeList().subscribe(function (data) {
                _this.types = data;
                _this.selectedType = _this.types[0];
                _this.loadingType = false;
            });
        }, 1000);
    };
    ParametersComponent.prototype.createReport = function () {
        var _this = this;
        this.loading = true;
        var dataReport = this.autoSystemService.CreateTelemehanicaReportdata(this.selectedLpu.kod_lpu, this.selectedKS.kod_ks, this.selectedLevel.level_id, this.selectedType.type_id);
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
            });
        }, 1000);
    };
    ParametersComponent.prototype.createExcelReport = function () {
        var _this = this;
        this.loadingExcel = true;
        var dataExcel = this.autoSystemService.CreateXLSfile(this.selectedLpu.kod_lpu, this.selectedKS.kod_ks, this.selectedLevel.level_id, this.selectedType.type_id);
        setTimeout(function () {
            dataExcel.subscribe(function (data) {
                _this.saveAsExcelFile(data, "Системы автоматики (параметры)");
                _this.loadingExcel = false;
            });
        }, 1000);
    };
    ParametersComponent.prototype.saveAsExcelFile = function (buffer, fileName) {
        var data = new Blob([buffer], {
            type: EXCEL_TYPE
        });
        FileSaver.saveAs(data, fileName + EXCEL_EXTENSION);
    };
    ParametersComponent.prototype.clearFilters = function () {
        this.selectedKS = this.kss[0];
        this.selectedLpu = this.lpus[0];
        this.selectedLevel = this.levels[0];
        this.selectedType = this.types[0];
    };
    ParametersComponent = tslib_1.__decorate([
        Component({
            selector: 'app-parameters',
            templateUrl: './parameters.component.html',
            styleUrls: ['./parameters.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [AutoSystemService])
    ], ParametersComponent);
    return ParametersComponent;
}());
export { ParametersComponent };
//# sourceMappingURL=parameters.component.js.map