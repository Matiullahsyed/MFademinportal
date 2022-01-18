import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DevLogsService } from '../Shared/services/dev-logs.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  emailid;
  passwd;
  invalidLogin;
  formdata;
  constructor(private devLogsService: DevLogsService,private router: Router) { }

  ngOnInit() {
    this.formdata = new FormGroup({
      emailid: new FormControl(""),
      passwd: new FormControl("")
   });
   
  }
  hasRoute(route: string) {
    return this.router.url.includes(route);
  }
  onClickSubmit(data) {
    this.emailid = data.emailid;
    this.passwd = data.passwd;
    let body = {
      Admin_Email: this.emailid,
      Admin_Password: this.passwd
    };
    this.devLogsService.LoginPostDetails(body).subscribe(data=>{
      if(data !=null && data.length > 0)
      {
        const token = (<any>data[0].user_Token);
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(['/dev-logs']);
      }
  else{
    this.ngOnInit();
  }
    },
    
    erorr=>{
      this.invalidLogin = true;
      console.log(erorr)
    })
  }
}
