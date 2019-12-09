import { ImmutableObject } from 'seamless-immutable';

export interface ISignupData {
  name: string;
  surname: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface IAuthInitialState {
  id: number;
  token: string;
  refreshToken: string;
}

export interface ILoginResponse {
  Id: string;
  access_token: string;
  refresh_token: string;
}

export interface IAuthState extends ImmutableObject<IAuthInitialState> {}
