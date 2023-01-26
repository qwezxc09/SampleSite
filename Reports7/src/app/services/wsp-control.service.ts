import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WspControlService {

  constructor(private http: HttpClient) { }

  CreateReportIntervalsLPU(stDate: string, endDate: string, kodlpu: number, minLen: number, maxLen: number) {
    const body = { kodlpu: kodlpu, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
    return this.http.post('getDataIntervalsLPU', body);
  }
  CreateXLSfileLPU(stDate: string, endDate: string, kodlpu: number, minLen: number, maxLen: number) {
    const body = { kodlpu: kodlpu, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
    return this.http.post('getDataIntervalsLPUExcel', body, { responseType: "blob" });
  }
  CreateReportIntervalsKC(stDate: string, endDate: string, kodkc: number, kodks: number, minLen: number, maxLen: number) {
    const body = { kodkc: kodkc, kodks: kodks, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
    return this.http.post('getDataIntervalsKC', body);
  }
  CreateXLSfileKC(stDate: string, endDate: string, kodkc: number, kodks: number, minLen: number, maxLen: number) {
    const body = { kodkc: kodkc, kodks: kodks, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
    return this.http.post('getDataIntervalsKCExcel', body, { responseType: "blob" });
  }
  CreateReportIntervalsManualTags(stDate: string, endDate: string, kodkc: number, kodks: number, objId: number, minLen: number, maxLen: number) {
    const body = { kodkc: kodkc, kodks: kodks, objId: objId, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
    return this.http.post('getDataIntervalsManualTags', body);
  }
  CreateXLSfileManualTags(stDate: string, endDate: string, kodkc: number, kodks: number, objId: number, minLen: number, maxLen: number) {
    const body = { kodkc: kodkc, kodks: kodks, objId: objId, startdt: stDate, enddt: endDate, minLen: minLen, maxLen: maxLen };
    return this.http.post('getDataIntervalsManualTagsExcel', body, { responseType: "blob" });
  }
  GetLpuList() {
    return this.http.get<any>('wsp/getLpuList')
  }
  GetKSList() {
    return this.http.get<any>('wsp/getKSList')
  }
  GetKCList(kodks: number) {
    const body = { kodks: kodks };
    return this.http.post('wsp/getKCList', body)
  }
  GetObjectTypeList() {
    return this.http.get<any>('wsp/getObjTypeList')
  }
  GetIntervalsList() {
    return this.http.get<any>('wsp/getIntervalsList')
  }
}
