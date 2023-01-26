import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var WspControlService = /** @class */ (function () {
    function WspControlService(http) {
        this.http = http;
    }
    WspControlService.prototype.CreateReportIntervalsLPU = function (stDate, endDate, kodlpu, minLen, maxLen) {
        var body = { kodlpu: kodlpu, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
        return this.http.post('getDataIntervalsLPU', body);
    };
    WspControlService.prototype.CreateXLSfileLPU = function (stDate, endDate, kodlpu, minLen, maxLen) {
        var body = { kodlpu: kodlpu, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
        return this.http.post('getDataIntervalsLPUExcel', body, { responseType: "blob" });
    };
    WspControlService.prototype.CreateReportIntervalsKC = function (stDate, endDate, kodkc, kodks, minLen, maxLen) {
        var body = { kodkc: kodkc, kodks: kodks, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
        return this.http.post('getDataIntervalsKC', body);
    };
    WspControlService.prototype.CreateXLSfileKC = function (stDate, endDate, kodkc, kodks, minLen, maxLen) {
        var body = { kodkc: kodkc, kodks: kodks, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
        return this.http.post('getDataIntervalsKCExcel', body, { responseType: "blob" });
    };
    WspControlService.prototype.CreateReportIntervalsManualTags = function (stDate, endDate, kodkc, kodks, objId, minLen, maxLen) {
        var body = { kodkc: kodkc, kodks: kodks, objId: objId, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
        return this.http.post('getDataIntervalsManualTags', body);
    };
    WspControlService.prototype.CreateXLSfileManualTags = function (stDate, endDate, kodkc, kodks, objId, minLen, maxLen) {
        var body = { kodkc: kodkc, kodks: kodks, objId: objId, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
        return this.http.post('getDataIntervalsManualTagsExcel', body, { responseType: "blob" });
    };
    WspControlService.prototype.GetLpuList = function () {
        return this.http.get('wsp/getLpuList');
    };
    WspControlService.prototype.GetKSList = function () {
        return this.http.get('wsp/getKSList');
    };
    WspControlService.prototype.GetKCList = function (kodks) {
        var body = { kodks: kodks };
        return this.http.post('wsp/getKCList', body);
    };
    WspControlService.prototype.GetObjectTypeList = function () {
        return this.http.get('wsp/getObjTypeList');
    };
    WspControlService.prototype.GetIntervalsList = function () {
        return this.http.get('wsp/getIntervalsList');
    };
    WspControlService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], WspControlService);
    return WspControlService;
}());
export { WspControlService };
//# sourceMappingURL=wsp-control.service.js.map