import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SignUpComponent } from './sign-up/sign-up.component';
import { SignInComponent } from './sign-in/sign-in.component';

import { AccountService } from './shared/account.service';
import { CookieService } from 'ngx-cookie-service';
import { SignAuthGuard } from './sign.auth.guard';

const appRoutes: Routes = [
  { path: 'account', component: SignInComponent, canActivate: [SignAuthGuard] },
  { path: 'account/sign-up', component: SignUpComponent, canActivate: [SignAuthGuard] },
  { path: 'account/sign-in', component: SignInComponent, canActivate: [SignAuthGuard] }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule
  ],
  declarations: [
    SignUpComponent,
    SignInComponent
  ],
  providers: [
    AccountService,
    CookieService,
    SignAuthGuard
  ]
})

export class AccountModule { }
