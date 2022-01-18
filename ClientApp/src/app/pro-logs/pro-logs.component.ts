import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DevLogsService } from '../Shared/services/dev-logs.service';
import { PagerService } from '../Shared/services/pager.service';

@Component({
  selector: 'app-pro-logs',
  templateUrl: './pro-logs.component.html',
  styleUrls: ['./pro-logs.component.css']
})
export class ProLogsComponent implements OnInit {
  public pageno: number = 1;
  pager: any = {};
  public TotalRecords: number;
  public PageSize: number=20;
  public TotalPages: number;
  public devUserLogsData: any[];
  public userData: any[];
  userId:number;
  userEmail:any;
  name:string;
  loggedDateTime:any;
  note:string;
  companyId:number;
  totalRecords:number;
  constructor(private devLogsService: DevLogsService,
    private pagerService: PagerService,private router: Router) { }

  ngOnInit() {
    this.getDraftPostDetails();
  }
  getDraftPostDetails() {
    
    let body = {
      CurrentPageIndex: this.pageno,
      PerPageCount: this.PageSize,
      TotalPageCount: this.TotalPages,
    };
    this.devUserLogsData = [];
    this.devLogsService.GetProductionDetails(body).subscribe(data=>{
      this.devUserLogsData=data;
      if (this.devUserLogsData != undefined && this.devUserLogsData.length > 0) {
        this.TotalPages = this.devUserLogsData[0].totalRecords;
        this.PageSize = this.devUserLogsData[0].pageSize;
        this.TotalRecords = this.devUserLogsData[1].totalRecords;
        this.setPagedraftPost(this.pageno);
      }
    },
    erorr=>{
      console.log(erorr)
    })
  }
  setPagedraftPost(page: number) {
    if (page < 1 || page > this.TotalPages) {
      return;
    }
    // get pager object from service
    this.pager = this.pagerService.getPager(
      this.TotalRecords,
      page,
      this.PageSize
    );
  }
  getpagedraftPost(page: number) {
    this.pageno = page;
    this.getDraftPostDetails();
  }
  hasRoute(route: string) {
    return this.router.url.includes(route);
  }
}
