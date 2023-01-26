import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ParamListService {

  constructor(private http: HttpClient) { }

  CreateReportParamList(session: string, lpuTitle: string, errId: number, dts: string) {
    const body = { session: session, lpuTitle: lpuTitle, errId: errId, dts: dts };
    return this.http.post('getDataParamList', body);
  }
  CreateXLSfile(session: string, lpuTitle: string, errId: number, dts: string) {
    const body = { session: session, lpuTitle: lpuTitle, errId: errId, dts: dts };
    return this.http.post('getDataParamListExcel', body, { responseType: "blob" });
  }
}
