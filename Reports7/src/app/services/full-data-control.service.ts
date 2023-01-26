import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Lpu_NSI } from '../Model/Models';

@Injectable({
  providedIn: 'root'
})
export class FullDataControlService {

  constructor(private http: HttpClient) { }

  CreateReportPeriod(stDate: string, endDate: string, lpuList: Lpu_NSI[]) {
    const body = { lpulist: lpuList, startdt: stDate, enddt: endDate };
    return this.http.post('getDataListPeriod', body);
  }
  CreateReportLive2(stDate: string, endDate: string, lpuList: Lpu_NSI[]) {
    const body = { lpulist: lpuList, startdt: stDate, enddt: endDate };
    return this.http.post('getDataListLive2', body);
  }
  CreateXLSfilePeriod(stDate: string, endDate: string, lpuList: Lpu_NSI[]) {
    const body = { lpulist: lpuList, startdt: stDate, enddt: endDate };
    return this.http.post('getDataListPeriodExcel', body, { responseType: "blob" });
  }
  CreateReportLive(lpuList: Lpu_NSI[]) {
    const body = { lpulist: lpuList};
    return this.http.post('getDataListLive', body);
  }
  CreateXLSfileLive(stDate: string, endDate: string, lpuList: Lpu_NSI[]) {
    const body = { lpulist: lpuList, startdt: stDate, enddt: endDate };
    return this.http.post('getDataListLiveExcel', body, { responseType: "blob" });
  }
  CreateReportDay(Dt: string, endDate: string, lpuList: Lpu_NSI[]) {
    const body = { lpulist: lpuList, startdt: Dt, enddt: endDate };
    return this.http.post('getDataListDay', body);
  }
  CreateXLSfileDay(Dt: string, endDate: string, lpuList: Lpu_NSI[]) {
    const body = { lpulist: lpuList, startdt: Dt, enddt: endDate };
    return this.http.post('getDataListDayExcel', body, { responseType: "blob" });
  }
  GetLpuList() {
    return this.http.get<any>('fulldata/getLpuList')
  }
}
