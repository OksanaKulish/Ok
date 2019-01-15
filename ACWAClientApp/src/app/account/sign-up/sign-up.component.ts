import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { AccountService } from '../shared/account.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})

export class SignUpComponent implements OnInit {
  constructor(private accountService: AccountService,
    private router: Router,
    private titleService: Title) { }

  public showAllErrors = false;
  public errors: string[];
  private status: number;

  signUpForm = new FormGroup({
    Email: new FormControl('', [
      Validators.required,
      Validators.email,
      Validators.maxLength(256)
    ]),
    Password: new FormControl('', [
      Validators.required,
      Validators.minLength(9)
    ]),
    ConfirmPassword: new FormControl('', [
      Validators.required,
      Validators.minLength(9),
      Validators.maxLength(32)
    ]),
    Info: new FormControl('', [
      Validators.maxLength(256)
    ])
  });

  ngOnInit() {
    this.setTitle('Sign Up - ACWA');
  }

  public onSubmitSignUpForm(): void {
    if (!this.signUpForm.invalid) {
      this.accountService.SignUp(this.signUpForm.value['Email'], this.signUpForm.value['Password'], this.signUpForm.value['Info'])
        .subscribe(x => this.status = x, (error: any) => {
          this.status = error.status;
          this.errors = (JSON.parse(error.text()))[''];
        }, () => {
          this.showAllErrors = false;
          if (this.status === 200) {
            this.accountService.SignIn(this.signUpForm.value['Email'], this.signUpForm.value['Password'])
              .subscribe(() => {}, () => {}, () => {
                this.router.navigate(['/users']);
            });
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
