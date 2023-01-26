import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var ParamListService = /** @class */ (function () {
    function ParamListService(http) {
        this.http = http;
    }
    ParamListService.prototype.CreateReportParamList = function (session, lpuTitle, errId, dts) {
        var body = { session: session, lpuTitle: lpuTitle, errId: errId, dts: dts };
        return this.http.post('getDataParamList', body);
    };
    ParamListService.prototype.CreateXLSfile = function (session, lpuTitle, errId, dts) {
        var body = { session: session, lpuTitle: lpuTitle, errId: errId, dts: dts };
        return this.http.post('getDataParamListExcel', body, { responseType: "blob" });
    };
    ParamListService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], ParamListService);
    return ParamListService;
}());
export { ParamListService };
//# sourceMappingURL=param-list.service.js.map