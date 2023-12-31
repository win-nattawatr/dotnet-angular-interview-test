import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import {
  EditableUserData,
  IUser,
  IUserResult,
  User,
  UserResult,
} from '../models/user.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable()
export class UserManagementService {
  constructor(private _httpCilent: HttpClient) {}

  getUsers(page: number, size: number): Observable<UserResult> {
    const httpOptions = {
      params: {
        page,
        size,
      },
    };
    return this._httpCilent
      .get<IUserResult>(
        `${environment.apiBaseUrl}/api/UserManagement/GetUsers`,
        httpOptions
      )
      .pipe(map((res) => new UserResult(res)));
  }

  addUser(userData: EditableUserData): Observable<User> {
    return this._httpCilent
      .post<IUser>(
        `${environment.apiBaseUrl}/api/UserManagement/Create`,
        userData
      )
      .pipe(map((res) => new User(res)));
  }

  updateUser(hn: string, userData: EditableUserData): Observable<User> {
    return this._httpCilent
      .put<IUser>(
        `${environment.apiBaseUrl}/api/UserManagement/Update/${hn}`,
        userData
      )
      .pipe(map((res) => new User(res)));
  }

  deleteUser(hn: string): Observable<void> {
    return this._httpCilent.delete<void>(
      `${environment.apiBaseUrl}/api/UserManagement/Delete/${hn}`
    );
  }
}
