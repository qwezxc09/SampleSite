import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var CraneService = /** @class */ (function () {
    function CraneService(http) {
        this.http = http;
    }
    CraneService.prototype.CreateCraneDataReport = function (stDate, endDate, lpuName, kpName) {
        var body = { startdt: stDate, enddt: endDate, lpuName: lpuName, kpName: kpName };
        return this.http.post('crane/getReportData', body);
    };
    CraneService.prototype.GetCraneNSIData = function (lpuName, kpName) {
        var body = { lpuName: lpuName, kpName: kpName };
        return this.http.post('crane/getNSIData', body);
    };
    CraneService.prototype.SaveCraneNSIData = function (nsiList) {
        var body = { nsiList: nsiList };
        return this.http.post('saveNSIData', body);
    };
    CraneService.prototype.CreateXLSfile = function (stDate, endDate, lpuName, kpName, showAll) {
        var body = { startdt: stDate, enddt: endDate, lpuName: lpuName, kpName: kpName, showAll: showAll };
        return this.http.post('getCraneDataReportExcel', body, { responseType: "blob" });
    };
    CraneService.prototype.CheckUserData = function (userName, password) {
        var body = { userName: userName, password: password };
        return this.http.post('crane/checkUserData', body);
    };
    CraneService.prototype.GetLpuList = function () {
        return this.http.get('crane/getLpuList');
    };
    CraneService.prototype.GetKPList = function (lpuName) {
        var body = { lpuName: lpuName };
        return this.http.post('crane/getKPList', body);
    };
    CraneService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], CraneService);
    return CraneService;
}());
export { CraneService };
//# sourceMappingURL=crane.service.js.map