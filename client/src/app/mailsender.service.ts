import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MailsenderService {

  constructor(private http: HttpClient) { }

  url: string = "https://localhost:5001/api/task/msend";

  sendMail(sendData: any) {

    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }

    return this.http.post<any>(this.url, sendData,httpOptions);
  }
}
