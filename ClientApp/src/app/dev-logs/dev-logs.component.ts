import { Component, OnInit } from '@angular/core';
import { DevLogsService } from '../Shared/services/dev-logs.service';
import { PagerService } from '../Shared/services/pager.service';

@Component({
  selector: 'app-dev-logs',
  templateUrl: './dev-logs.component.html',
  styleUrls: ['./dev-logs.component.css']
})

export class DevLogsComponent implements OnInit {

  pagenoHistory: number = 1;
  public pageno: number = 1;
  pagerHistory: any = {};
  pager: any = {};
  pagedItems: any[];
  public TotalRecords: number;
  public PageSize: number=20;
  public TotalPages: number;
  public TotalRecordsHistory: number;
  public PageSizeHistory: number;
  public TotalPagesHistory: number;
  public devUserLogsData: any[];
  public userData: any[];
  userId:number;
  userEmail:any;
  name:string;
  loggedDateTime:any;
  note:string;
  companyId:number;
  totalRecords:number;
  constructor(
    private devLogsService: DevLogsService,
    private pagerService: PagerService
    ) { }

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
    this.devLogsService.GetDraftPostDetails(body).subscribe(data=>{
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
    debugger;
    this.pageno = page;
    this.getDraftPostDetails();
  }

}
