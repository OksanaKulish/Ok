import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { UserComponent } from './users/user/user.component';
import { AddUserComponent } from './users/add-user/add-user.component';

import { UserApiService } from './users/shared/user-api.service';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { PaginationComponent } from './extensions/pagination/pagination.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalDeleteComponent } from './extensions/modal-delete/modal-delete.component';
import { AccountModule } from './account/account.module';
import { AuthGuard } from './auth.guard';
import { NavbarComponent } from './extensions/navbar/navbar.component';

const appRoutes: Routes = [
  { path: '', component: UserListComponent, canActivate: [AuthGuard] },
  { path: 'users/add', component: AddUserComponent, canActivate: [AuthGuard] },
  { path: 'users/edit/:id', component: AddUserComponent, canActivate: [AuthGuard] },
  { path: 'users', component: UserListComponent, canActivate: [AuthGuard] },
  { path: 'users/:page', component: UserListComponent, canActivate: [AuthGuard] },
  { path: 'user/:id/:returnUrl', component: UserComponent, canActivate: [AuthGuard] }
];

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    PaginationComponent,
    UserComponent,
    ModalDeleteComponent,
    AddUserComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AngularFontAwesomeModule,
    RouterModule.forRoot(appRoutes),
    NgbModule,
    ReactiveFormsModule,
    AccountModule
  ],
  providers: [
    UserApiService,
    Title,
    AuthGuard
  ],
  entryComponents: [
    ModalDeleteComponent
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
