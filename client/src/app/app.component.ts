import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import {MailsenderService} from './mailsender.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';

  constructor(private mailService:MailsenderService){}


  sendMail(dataForm:NgForm){

    this.mailService.sendMail(JSON.stringify(dataForm)).subscribe(data=>{
    },error=>{
      console.log("error")
    })

    console.log(JSON.stringify(dataForm));

  }

}
