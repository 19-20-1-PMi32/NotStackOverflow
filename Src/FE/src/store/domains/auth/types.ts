import { ImmutableObject } from 'seamless-immutable';

export interface ISignupData {
  name: string;
  surname: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface IAuthInitialState {
}

export interface IAuthState extends ImmutableObject<IAuthInitialState> {}
