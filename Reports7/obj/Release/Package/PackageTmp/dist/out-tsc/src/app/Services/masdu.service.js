import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var MasduService = /** @class */ (function () {
    function MasduService(http) {
        this.http = http;
    }
    MasduService.prototype.GetSessionList = function () {
        return this.http.get('masdu/getSessionList');
    };
    MasduService.prototype.CreateReportMasdu = function (stDate, endDate, session) {
        var body = { session: session, startdt: stDate, enddt: endDate };
        return this.http.post('getMasduEsgList', body);
    };
    MasduService.prototype.CreateReportMasduLPU = function (stDate, endDate, session) {
        var body = { session: session, startdt: stDate, enddt: endDate };
        return this.http.post('getMasduEsgLpuList', body);
    };
    MasduService.prototype.CreateReportMasduPeriod = function (stDate, endDate, session) {
        var body = { session: session, startdt: stDate, enddt: endDate };
        return this.http.post('getMasduEsgPeriodList', body);
    };
    MasduService.prototype.CreateReportMasduLPUPeriod = function (stDate, endDate, session) {
        var body = { session: session, startdt: stDate, enddt: endDate };
        return this.http.post('getMasduEsgLpuPeriodList', body);
    };
    MasduService.prototype.CreateXLSfile = function (stDate, endDate, session) {
        var body = { session: session, startdt: stDate, enddt: endDate };
        return this.http.post('getMasduEsgListExcel', body, { responseType: "blob" });
    };
    MasduService.prototype.CreateXLSfilePeriod = function (stDate, endDate, session) {
        var body = { session: session, startdt: stDate, enddt: endDate };
        return this.http.post('getMasduEsgPeriodListExcel', body, { responseType: "blob" });
    };
    MasduService.prototype.CreateXLSfileLpu = function (stDate, endDate, session) {
        var body = { session: session, startdt: stDate, enddt: endDate };
        return this.http.post('getMasduEsgLpuListExcel', body, { responseType: "blob" });
    };
    MasduService.prototype.CreateXLSfileLpuPeriod = function (stDate, endDate, session) {
        var body = { session: session, startdt: stDate, enddt: endDate };
        return this.http.post('getMasduEsgLpuPeriodListExcel', body, { responseType: "blob" });
    };
    MasduService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], MasduService);
    return MasduService;
}());
export { MasduService };
//# sourceMappingURL=masdu.service.js.map