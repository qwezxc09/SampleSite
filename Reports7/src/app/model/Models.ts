export interface Lpu_NSI {
  id_lpu: number;
  kod_lpu: number;
  title: string;
}
export interface KS_NSI {
  id_ks: number;
  kod_ks: number;
  title: string;
}
export interface KC_NSI {
  id_kc: number;
  kod_kc: number;
  title: string;
}
export interface ObjType {
  idTagType: number;
  Description: string;
}
export interface Interval_NSI {
  interval_id: number;
  title: string;
}
export interface Level_DTO {
  level_id: number;
  title: string; 
}
export interface Type_DTO {
  type_id: number;
  title: string;
}
export interface Session_DTO {
  session_id: number;
  cod: string;
  description: string;
}
export interface QualityTypes_DTO {
  type_id: number;
  title: string;
}
export interface Display_NSI {
  Id: number;
  NsiValue: string;
}
export interface ZAR_NSI_WEB {
  Id: number;
  LPU_Name: string;
  KP_Name: string;
  kodZAR_SLTM: string;
  kodZAR_SODU: string;
  Tagname: string;
  ShortZAR_Name: string;
  Comment: string;
  LongZAR_Name: string;
  Added: boolean;
  Deleted: boolean;
  Changed: boolean;
  isError: boolean;
  errorMessage: string;
}
export interface ZAR_STATES_REPORT {
  LPU_Name: string;
  KP_Name: string;
  kodZAR_SLTM: string;
  kodZAR_SODU: string;
  TagName: string;
  hasRearrange: boolean;
  Quality: number;
  State: string;
  Value: number;
  RearrangeDate: Date;
  RearrangeDateDisplay: string;
  isAuto: boolean;
  isManual: boolean;
  isNoValue: boolean;
  isError: boolean;
  errorMessage: string;
}
