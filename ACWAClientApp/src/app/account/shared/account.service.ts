import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class AccountService {
  constructor(private http: Http,
    private cookieService: CookieService) { }

  private userEmail: string;

  public isLoggedIn(): boolean {
    return !!this.cookieService.get('auth_token');
  }

  public getUserEmail(): string {
    return this.cookieService.get('user_email');
  }

  // 200: Success
  public SignUp(email: string, password: string, info: string): Observable<number> {
    const model: any = {
      Email: email,
      Password: password,
      Data: info
    };

    return this.http.post('/api/accounts/sign-up', model).pipe(
      map((x: Response) => {
        return x.status as number;
      })
    );
  }

  public SignIn(email: string, password: string): Observable<Response> {
    const model: any = {
      Email: email,
      Password: password
    };

    return this.http.post('/api/accounts/sign-in', model).pipe(
      map((data: Response) => {
        const _jsonData = JSON.parse(data.text());
        const _expires = Date.now() + _jsonData['expires_in'] * 1000;
        this.cookieService.set('auth_token', _jsonData['auth_token'], new Date(_expires));
        this.cookieService.set('user_email', email, new Date(_expires));
        return data;
      })
    );
  }

  public SignOut(): void {
    this.cookieService.deleteAll('/');
  }
}
