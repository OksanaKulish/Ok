import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { PaginationHelper } from './pagination-helper.model';
import { UserResponse } from './user-response.model';
import { AddUserRequest } from './add-user-request.model';
import { User } from './user.model';
import { UpdateUserRequest } from './update-user-request.model';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class UserApiService {
  constructor(private http: Http,
    private cookieService: CookieService) { }

  private options = { headers: new Headers( { ['Authorization']: 'Bearer ' + this.cookieService.get('auth_token') }) };

  public GetUserById(id: string): Observable<UserResponse> {
    return this.http.get('/api/users/' + id, this.options).pipe(
      map((data: Response) => {
        return data.json() as UserResponse;
      })
    );
  }

  public GetUserForEditById(id: string): Observable<User> {
    return this.http.get('/api/users/full/' + id, this.options).pipe(
      map((data: Response) => {
        return data.json() as User;
      })
    );
  }

  public GetUsers (page?: number, pageSize?: number): Observable<PaginationHelper<UserResponse>> {
    let parameters: string;
    if (page != null && pageSize != null) {
      parameters = '?page=' + page + '&pagesize=' + pageSize;
    } else if (page != null && pageSize == null) {
      parameters = '?page=' + page;
    } else if (page == null && pageSize != null) {
      parameters = '?pagesize=' + pageSize;
    } else {
      parameters = '';
    }

    return this.http.get('/api/users' + parameters, this.options).pipe(
      map((data: Response) => {
        return data.json() as PaginationHelper<UserResponse>;
      })
    );
  }

  public DeleteUser(id: string): void {
    this.http.delete('/api/users/' + id, this.options)
      .subscribe(() => {});
  }

  public AddUser(model: AddUserRequest): void {
    this.http.post('/api/users/add', model, this.options)
      .subscribe(() => {});
  }

  public UpdateUser(model: UpdateUserRequest): void {
    this.http.put('/api/users/update', model, this.options)
      .subscribe(() => {});
  }
}
