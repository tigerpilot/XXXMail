import { Component } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import {MailsenderService} from './mailsender.service';
import {MatSnackBar} from '@angular/material/snack-bar'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';

  constructor(private mailService:MailsenderService,private _snackBar: MatSnackBar){}


  sendMail(dataForm:NgForm){

    this.mailService.sendMail(JSON.stringify(dataForm)).subscribe(data=>{
      this._snackBar.open("Mesajınız göndərildi", "Uğurlu", {
        duration: 4000,
      });

      setTimeout(() => window.location.reload(), 4000);
      
    },error=>{
      this._snackBar.open("Xəta baş verdi", "Uğursuz", {
        duration: 4000,
      });
    })

    console.log(JSON.stringify(dataForm));

  }

}
