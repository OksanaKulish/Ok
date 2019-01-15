import { Component, OnInit } from '@angular/core';
import { AccountService } from './../../account/shared/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})

export class NavbarComponent implements OnInit {
  constructor(private accountService: AccountService,
    private router: Router) { }

  public isAuthorized: boolean;
  public userEmail: string;

  ngOnInit() {
    this.isAuthorized = this.accountService.isLoggedIn();
    if (this.isAuthorized) {
      this.userEmail = this.accountService.getUserEmail();
    }
  }

  public signOutOnClick(): void {
    this.accountService.SignOut();
    this.router.navigate(['/account']);
  }
}
