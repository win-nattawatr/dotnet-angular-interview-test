export class User {
  id?: number;
  hn?: string;
  firstname: string;
  lastname: string;
  phoneNumber: string;
  email: string;

  constructor(data: IUser) {
    this.id = data.id;
    this.hn = data.hn;
    this.firstname = data.firstname;
    this.lastname = data.lastname;
    this.phoneNumber = data.phoneNumber;
    this.email = data.email;
  }

  get fullname(): string {
    return `${this.firstname} ${this.lastname}`;
  }
}

export class UserResult {
  users: User[];
  total: number;

  constructor(data: IUserResult) {
    this.users = data.users.map((item) => new User(item));
    this.total = data.total;
  }
}

export interface IUser {
  id?: number;
  hn?: string;
  firstname: string;
  lastname: string;
  phoneNumber: string;
  email: string;
}

export interface IUserResult {
  users: IUser[];
  total: number;
}

export type EditableUserData = Omit<IUser, 'id' | 'hn'>;
