
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DevLogsService } from '../Shared/services/dev-logs.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  constructor(
    private router: Router,private devLogsService: DevLogsService
  ) {}
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  hasRoute(route: string) {
    return this.router.url.includes(route);
  }
  routingForExpiry(){
    this.router.navigate(['/expiry-update']);
  }
  routingForDevLogs(){
    this.router.navigate(['/dev-logs']);
  }
  routingForProdLogs(){
    this.router.navigate(['/pro-logs']);
  }
  routingForAddNewUser(){
    this.router.navigate(['/add-user']);
  }
  logOut() {
    localStorage.removeItem("jwt");
    this.router.navigate(['/login']);
 }

  prodSchedularReset(){
    debugger;
    this.devLogsService.SchedularResetDetails().subscribe(data=>{
    if(data == true){
      alert('Prod Schedular Reset Succesfully');
    }
    else{
      alert('Prod Schedular not Reseted');
    }
  },
  erorr=>{
    console.log(erorr);
  });
 }

 devSchedularReset(){
   debugger;
   this.devLogsService.DevSchedularResetDetails().subscribe(data=>{
   if(data == true){
     alert('Dev Schedular Reset Succesfully');
   }
   else{
     alert('Dev Schedular not Reseted');
   }
 },
 erorr=>{
   console.log(erorr);
 });
}
}
