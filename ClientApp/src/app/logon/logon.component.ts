import { Component } from '@angular/core';

@Component({
  selector: 'logon-component',
  templateUrl: './logon.component.html',
})
export class LogonComponent {
  failedAttempts = 0;

  tryToLogon(): void {
    //this.loggedIn = !!localStorage.getItem('auth_token');

    //if (this.loggedIn) {
    //  this.failedAttempts = 0;
    //} else {
    //  this.failedAttempts++;
    //}
  }
}
