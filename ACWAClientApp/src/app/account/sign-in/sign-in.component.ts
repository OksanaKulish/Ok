import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { AccountService } from './../shared/account.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})

export class SignInComponent implements OnInit {
  constructor(private accountService: AccountService,
    private router: Router,
    private titleService: Title) { }

  public showAllErrors = false;
  public errors: string[];
  private status: number;

  signInForm = new FormGroup({
    Email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    Password: new FormControl('', [
      Validators.required
    ])
  });

  ngOnInit() {
    this.setTitle('Sign in - ACWA');
  }

  public onSubmitSignInForm(): void {
    if (!this.signInForm.invalid) {
      this.accountService.SignIn(this.signInForm.value['Email'], this.signInForm.value['Password'])
        .subscribe(x => this.status = x.status, (error: any) => {
          this.status = error.status;
          this.errors = (JSON.parse(error.text()))[''];
        }, () => {
          this.showAllErrors = false;
          if (this.status === 200) {
            this.router.navigate(['/users']);
          }
      });
    } else {
      this.showAllErrors = true;
    }
  }

  private setTitle(newTitle: string): void {
    this.titleService.setTitle(newTitle);
  }
}
