import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DevLogsService } from '../Shared/services/dev-logs.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  emailid;
  passwd;
  formdata;
  constructor(private devLogsService: DevLogsService,private router: Router) { }

  ngOnInit() {
    this.formdata = new FormGroup({
      emailid: new FormControl(""),
      passwd: new FormControl("")
   });
  }
  onClickSubmit(data) {
    debugger;
    this.emailid = data.emailid;
    this.passwd = data.passwd;
    let body = {
      Admin_Email: this.emailid,
      Admin_Password: this.passwd
    };
    this.devLogsService.AddUserPostDetails(body).subscribe(data=>{
      debugger;
      if(data ==true)
      {
      this.router.navigate(['/login']);
      }
  else{
    this.ngOnInit();
  }
    },
    
    erorr=>{

      console.log(erorr)
    })
  }
}
