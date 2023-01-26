import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MasduService {

  constructor(private http: HttpClient) { }

  GetSessionList() {
    return this.http.get<any>('masdu/getSessionList')
  }

  CreateReportMasdu(stDate: string, endDate: string, session: string) {
    const body = { session: session, startdt: stDate, enddt: endDate };
    return this.http.post('getMasduEsgList', body);
  }

  CreateReportMasduLPU(stDate: string, endDate: string, session: string) {
    const body = { session: session, startdt: stDate, enddt: endDate };
    return this.http.post('getMasduEsgLpuList', body);
  }

  CreateReportMasduPeriod(stDate: string, endDate: string, session: string) {
    const body = { session: session, startdt: stDate, enddt: endDate };
    return this.http.post('getMasduEsgPeriodList', body);
  }

  CreateReportMasduLPUPeriod(stDate: string, endDate: string, session: string) {
    const body = { session: session, startdt: stDate, enddt: endDate };
    return this.http.post('getMasduEsgLpuPeriodList', body);
  }
  CreateXLSfile(stDate: string, endDate: string, session: string) {
    const body = { session: session, startdt: stDate, enddt: endDate };
    return this.http.post('getMasduEsgListExcel', body, { responseType: "blob" });
  }
  CreateXLSfilePeriod(stDate: string, endDate: string, session: string) {
    const body = { session: session, startdt: stDate, enddt: endDate };
    return this.http.post('getMasduEsgPeriodListExcel', body, { responseType: "blob" });
  }
  CreateXLSfileLpu(stDate: string, endDate: string, session: string) {
    const body = { session: session, startdt: stDate, enddt: endDate };
    return this.http.post('getMasduEsgLpuListExcel', body, { responseType: "blob" });
  }
  CreateXLSfileLpuPeriod(stDate: string, endDate: string, session: string) {
    const body = { session: session, startdt: stDate, enddt: endDate };
    return this.http.post('getMasduEsgLpuPeriodListExcel', body, { responseType: "blob" });
  }
}
