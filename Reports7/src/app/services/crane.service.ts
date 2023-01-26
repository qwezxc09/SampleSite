import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ZAR_NSI_WEB } from '../Model/Models';

@Injectable({
  providedIn: 'root'
})
export class CraneService {

  constructor(private http: HttpClient) { }

  CreateCraneDataReport(stDate: string, endDate: string, lpuName: string, kpName: string) {
    const body = { startdt: stDate, enddt: endDate, lpuName: lpuName, kpName: kpName };
    return this.http.post('crane/getReportData', body);
  }
  GetCraneNSIData(lpuName: string, kpName: string) {
    const body = {lpuName: lpuName, kpName: kpName };
    return this.http.post('crane/getNSIData', body);
  }
  SaveCraneNSIData(nsiList: ZAR_NSI_WEB[]) {
    const body = { nsiList: nsiList };
    return this.http.post('saveNSIData', body);
  }
  CreateXLSfile(stDate: string, endDate: string, lpuName: string, kpName: string, showAll: boolean) {
    const body = { startdt: stDate, enddt: endDate, lpuName: lpuName, kpName: kpName, showAll: showAll };
    return this.http.post('getCraneDataReportExcel', body, { responseType: "blob" });
  }
  CheckUserData(userName: string, password: string) {
    const body = { userName: userName, password: password };
    return this.http.post('crane/checkUserData', body);
  }
  GetLpuList() {
    return this.http.get<any>('crane/getLpuList')
  }
  GetKPList(lpuName: string) {
    const body = { lpuName: lpuName };
    return this.http.post('crane/getKPList', body)
  }
}
