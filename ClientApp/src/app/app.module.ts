import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DevLogsComponent } from './dev-logs/dev-logs.component';
import { LoginComponent } from './login/login.component';
import { AddUserComponent } from './add-user/add-user.component';
import { ProLogsComponent } from './pro-logs/pro-logs.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuardService } from './Shared/services/auth-guard.service';
import { ExpiryUpdateComponent } from './expiry-update/expiry-update.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DevLogsComponent,
    LoginComponent,
    AddUserComponent,
    ProLogsComponent,
    ExpiryUpdateComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      //{ path: 'login', component: LoginComponent, pathMatch: 'full' },
      {path:'login',component:LoginComponent},
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      {path:'dev-logs',component:DevLogsComponent,canActivate: [AuthGuardService]},
      {path:'add-user',component:AddUserComponent,canActivate: [AuthGuardService]},
      {path:'pro-logs',component:ProLogsComponent,canActivate: [AuthGuardService]},
      {path:'expiry-update',component:ExpiryUpdateComponent,canActivate: [AuthGuardService]}
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:44374"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [AuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
