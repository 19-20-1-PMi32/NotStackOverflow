import { ImmutableObject } from 'seamless-immutable';

import { IQuestionInfo } from '../questions';

export interface IUserDataResponse {
  id: number;
  name: string;
  surname: string;
  nickName: string;
  email: string;
  job: string;
}

export interface IUpdateUserData {
  id: string;
  name: string;
  surname: string;
  nickName: string;
  email: string;
  job: string;
}

export interface IUserInitialState extends IUserDataResponse {
  questions: IQuestionInfo[];
}

export interface IUserState extends ImmutableObject<IUserInitialState> {}
