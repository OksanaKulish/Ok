import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AccountService } from './shared/account.service';

@Injectable()
export class SignAuthGuard implements CanActivate {
  constructor(private accountService: AccountService,
    private router: Router) {}

  canActivate() {
    if (!this.accountService.isLoggedIn()) {
      return true;
    }

    this.router.navigate(['/']);
    return false;
  }
}
