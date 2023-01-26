import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var FullDataControlService = /** @class */ (function () {
    function FullDataControlService(http) {
        this.http = http;
    }
    FullDataControlService.prototype.CreateReportPeriod = function (stDate, endDate, lpuList) {
        var body = { lpulist: lpuList, startdt: stDate, enddt: endDate };
        return this.http.post('getDataListPeriod', body);
    };
    FullDataControlService.prototype.CreateReportLive2 = function (stDate, endDate, lpuList) {
        var body = { lpulist: lpuList, startdt: stDate, enddt: endDate };
        return this.http.post('getDataListLive2', body);
    };
    FullDataControlService.prototype.CreateXLSfilePeriod = function (stDate, endDate, lpuList) {
        var body = { lpulist: lpuList, startdt: stDate, enddt: endDate };
        return this.http.post('getDataListPeriodExcel', body, { responseType: "blob" });
    };
    FullDataControlService.prototype.CreateReportLive = function (lpuList) {
        var body = { lpulist: lpuList };
        return this.http.post('getDataListLive', body);
    };
    FullDataControlService.prototype.CreateXLSfileLive = function (stDate, endDate, lpuList) {
        var body = { lpulist: lpuList, startdt: stDate, enddt: endDate };
        return this.http.post('getDataListLiveExcel', body, { responseType: "blob" });
    };
    FullDataControlService.prototype.CreateReportDay = function (Dt, endDate, lpuList) {
        var body = { lpulist: lpuList, startdt: Dt, enddt: endDate };
        return this.http.post('getDataListDay', body);
    };
    FullDataControlService.prototype.CreateXLSfileDay = function (Dt, endDate, lpuList) {
        var body = { lpulist: lpuList, startdt: Dt, enddt: endDate };
        return this.http.post('getDataListDayExcel', body, { responseType: "blob" });
    };
    FullDataControlService.prototype.GetLpuList = function () {
        return this.http.get('fulldata/getLpuList');
    };
    FullDataControlService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], FullDataControlService);
    return FullDataControlService;
}());
export { FullDataControlService };
//# sourceMappingURL=full-data-control.service.js.map