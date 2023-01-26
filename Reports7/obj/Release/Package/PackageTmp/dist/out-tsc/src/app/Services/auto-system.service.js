import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var AutoSystemService = /** @class */ (function () {
    function AutoSystemService(http) {
        this.http = http;
    }
    AutoSystemService.prototype.CreateTelemehanicaReportdata = function (kodlpu, kodks, kodlevel, kodtype) {
        var body = { kodlpu: kodlpu, kodks: kodks, kodlevel: kodlevel, kodtype: kodtype };
        return this.http.post('getTelemehanicaReportData', body);
    };
    AutoSystemService.prototype.CreateXLSfile = function (kodlpu, kodks, kodlevel, kodtype) {
        var body = { kodlpu: kodlpu, kodks: kodks, kodlevel: kodlevel, kodtype: kodtype };
        return this.http.post('getTelemehanicaReportDataExcel', body, { responseType: "blob" });
    };
    AutoSystemService.prototype.GetLpuList = function () {
        return this.http.get('autosystem/getLpuList');
    };
    AutoSystemService.prototype.GetKSList = function () {
        return this.http.get('autosystem/getKSList');
    };
    AutoSystemService.prototype.GetLevelList = function () {
        return this.http.get('autosystem/getLevelList');
    };
    AutoSystemService.prototype.GetTypeList = function () {
        return this.http.get('autosystem/getTypesList');
    };
    AutoSystemService.prototype.GetTelemehanicaKcData = function () {
        return this.http.get('getTelemehanicaKcData');
    };
    AutoSystemService.prototype.CreateXLSfileKC = function (idProcess) {
        var body = { idProcess: idProcess };
        return this.http.post('getTelemehanicaKcDataExcel', body, { responseType: "blob" });
    };
    AutoSystemService.prototype.GetTelemehanicaGpaData = function () {
        return this.http.get('getTelemehanicaGpaData');
    };
    AutoSystemService.prototype.CreateXLSfileGPA = function (idProcess) {
        var body = { idProcess: idProcess };
        return this.http.post('getTelemehanicaGpaDataExcel', body, { responseType: "blob" });
    };
    AutoSystemService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], AutoSystemService);
    return AutoSystemService;
}());
export { AutoSystemService };
//# sourceMappingURL=auto-system.service.js.map