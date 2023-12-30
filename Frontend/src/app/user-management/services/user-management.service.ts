import { Injectable } from '@angular/core';
import { map, of } from 'rxjs';
import { IUser, IUserResult, User, UserResult } from '../models/user.model';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserManagementService {
  constructor(private httpCilent: HttpClient) {}

  getUsers(page: number = 1, size?: number) {
    return of<IUserResult>(this._mockUserResult).pipe(
      map((res) => new UserResult(res))
    );
  }

  private _mockUserResult: IUserResult = {
    total: 6,
    results: [
      {
        id: 1,
        hn: '000001',
        firstname: 'firstname',
        lastname: 'lastname',
        phoneNumber: '0123456789',
        email: 'mail@mail.com',
      },
      {
        id: 1,
        hn: '000001',
        firstname: 'firstname',
        lastname: 'lastname',
        phoneNumber: '0123456789',
        email: 'mail@mail.com',
      },
      {
        id: 1,
        hn: '000001',
        firstname: 'firstname',
        lastname: 'lastname',
        phoneNumber: '0123456789',
        email: 'mail@mail.com',
      },
      {
        id: 1,
        hn: '000001',
        firstname: 'firstname',
        lastname: 'lastname',
        phoneNumber: '0123456789',
        email: 'mail@mail.com',
      },
      {
        id: 1,
        hn: '000001',
        firstname: 'firstname',
        lastname: 'lastname',
        phoneNumber: '0123456789',
        email: 'mail@mail.com',
      },
      {
        id: 1,
        hn: '000001',
        firstname: 'firstname',
        lastname: 'lastname',
        phoneNumber: '0123456789',
        email: 'mail@mail.com',
      },
    ],
  };
}
