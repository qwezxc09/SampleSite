import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var TagListService = /** @class */ (function () {
    function TagListService(http) {
        this.http = http;
    }
    TagListService.prototype.GetLpuList = function () {
        return this.http.get('tagList/getLpuList');
    };
    TagListService.prototype.GetQualityList = function () {
        return this.http.get('tagList/getQualityList');
    };
    TagListService.prototype.CreateReportTagList = function (kodlpu, qualityId) {
        var body = { kodlpu: kodlpu, qualityId: qualityId };
        return this.http.post('getDataTagList', body);
    };
    TagListService.prototype.CreateXLSfile = function (kodlpu, qualityId) {
        var body = { kodlpu: kodlpu, qualityId: qualityId };
        return this.http.post('getDataTagListExcel', body, { responseType: "blob" });
    };
    TagListService.prototype.CreateReportPeriodTagList = function (kodlpu, qualityId, stdate, enddt, typeData) {
        var body = { kodlpu: kodlpu, qualityId: qualityId, stdate: stdate, enddt: enddt, typeData: typeData };
        return this.http.post('getDataPeriodTagList', body);
    };
    TagListService.prototype.CreateXLSfilePeriod = function (kodlpu, qualityId, stdate, enddt, typeData) {
        var body = { kodlpu: kodlpu, qualityId: qualityId, stdate: stdate, enddt: enddt, typeData: typeData };
        return this.http.post('getDataPeriodTagListExcel', body, { responseType: "blob" });
    };
    TagListService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], TagListService);
    return TagListService;
}());
export { TagListService };
//# sourceMappingURL=tag-list.service.js.map