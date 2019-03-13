import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'logon-component',
  templateUrl: './logon.component.html',
})
export class LogonComponent {
  failedAttempts = 0;
  username:String;
  password:String;

  tryToLogon(): void {
    this.http.get<string[]>(this.baseUrl +
      'interface/logon/' +
      this.username +
      "/"+
      this.password).subscribe(result => {
        if (result[0] === "denied") {
          this.failedAttempts++;
        } else {
          localStorage.setItem("access_token", result[0]);
        }
      },
      error => console.error(error));
  }


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}
}
