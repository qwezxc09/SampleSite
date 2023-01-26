import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TagListService {

  constructor(private http: HttpClient) { }

  GetLpuList() {
    return this.http.get<any>('tagList/getLpuList')
  }
  GetQualityList() {
    return this.http.get<any>('tagList/getQualityList')
  }
  CreateReportTagList(kodlpu: number, qualityId: number) {
    const body = { kodlpu: kodlpu, qualityId: qualityId };
    return this.http.post('getDataTagList', body);
  }
  CreateXLSfile(kodlpu: number, qualityId: number) {
    const body = { kodlpu: kodlpu, qualityId: qualityId };
    return this.http.post('getDataTagListExcel', body, { responseType: "blob" });
  }
  CreateReportPeriodTagList(kodlpu: number, qualityId: number, stdate: string, enddt: string, typeData: number) {
    const body = { kodlpu: kodlpu, qualityId: qualityId, stdate: stdate, enddt: enddt, typeData: typeData };
    return this.http.post('getDataPeriodTagList', body);
  }
  CreateXLSfilePeriod(kodlpu: number, qualityId: number, stdate: string, enddt: string, typeData: number) {
    const body = { kodlpu: kodlpu, qualityId: qualityId, stdate: stdate, enddt: enddt, typeData: typeData };
    return this.http.post('getDataPeriodTagListExcel', body, { responseType: "blob" });
  }
}
