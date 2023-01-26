import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AutoSystemService {

  constructor(private http: HttpClient) { }

  CreateTelemehanicaReportdata(kodlpu: number, kodks: number, kodlevel: number, kodtype: number) {
    const body = { kodlpu: kodlpu, kodks: kodks, kodlevel: kodlevel, kodtype: kodtype };
    return this.http.post('getTelemehanicaReportData', body);
  }
  CreateXLSfile(kodlpu: number, kodks: number, kodlevel: number, kodtype: number) {
    const body = { kodlpu: kodlpu, kodks: kodks, kodlevel: kodlevel, kodtype: kodtype };
    return this.http.post('getTelemehanicaReportDataExcel', body, { responseType: "blob" });
  }

  GetLpuList() {
    return this.http.get<any>('autosystem/getLpuList')
  }

  GetKSList() {
    return this.http.get<any>('autosystem/getKSList')
  }

  GetLevelList() {
    return this.http.get<any>('autosystem/getLevelList')
  }

  GetTypeList() {
    return this.http.get<any>('autosystem/getTypesList')
  }

  GetTelemehanicaKcData() {
    return this.http.get<any>('getTelemehanicaKcData')
  }
  CreateXLSfileKC(idProcess: number) {
    const body = { idProcess: idProcess };
    return this.http.post('getTelemehanicaKcDataExcel', body, { responseType: "blob" });
  }

  GetTelemehanicaGpaData() {
    return this.http.get<any>('getTelemehanicaGpaData')
  }
  CreateXLSfileGPA(idProcess: number) {
    const body = { idProcess: idProcess };
    return this.http.post('getTelemehanicaGpaDataExcel', body, { responseType: "blob" });
  }
}
