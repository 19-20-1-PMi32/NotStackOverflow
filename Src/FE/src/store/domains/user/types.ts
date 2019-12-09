import { ImmutableObject } from 'seamless-immutable';

export interface IUserDataResponse {
  id: number;
  name: string;
  surname: string;
  nickName: string;
  email: string;
  job: string;
}

export interface IUserInitialState extends IUserDataResponse {
}

export interface IUserState extends ImmutableObject<IUserInitialState> {}
