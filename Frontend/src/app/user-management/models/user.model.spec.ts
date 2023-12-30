import { User } from './user.model';

describe('User', () => {
  it('should create an instance', () => {
    expect(
      new User({
        id: 1,
        hn: '000001',
        firstname: 'firstname',
        lastname: 'lastname',
        phoneNumber: '0123456789',
        email: 'mail@mail.com',
      })
    ).toBeTruthy();
  });
});
