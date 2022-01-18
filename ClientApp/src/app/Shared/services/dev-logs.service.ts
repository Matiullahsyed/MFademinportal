import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DevLogsService {

  constructor(private http: HttpClient) { }

  baseUrl: string = 'https://localhost:44374/api/';
  GetDraftPostDetails(obj:any){
    return this.http.post<any>(this.baseUrl + 'UserLogs/dev_logs', obj);
  }
  GetProductionDetails(obj:any){
    return this.http.post<any>(this.baseUrl + 'UserLogs/Pro_logs', obj);
  }
  LoginPostDetails(obj:any){
    return this.http.post<any>(this.baseUrl + 'Account/login', obj);
  }
  AddUserPostDetails(obj:any){
    return this.http.post<any>(this.baseUrl + 'Account/add_New_User', obj);
  }
  SchedularResetDetails(){
    return this.http.get(this.baseUrl + 'UserLogs/Feed_Reschedular');
  }
  DevSchedularResetDetails(){
    return this.http.get(this.baseUrl + 'UserLogs/Dev_Feed_Reschedular');
  }
}
