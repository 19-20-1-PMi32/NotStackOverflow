import { IPromiseAction } from 'types';

import { ILoginResponse } from './types';

export enum AuthActionTypeKeys {
  SIGNUP = 'auth/SIGNUP',
  SIGNUP_FULFILLED = 'auth/SIGNUP_FULFILLED',
  SIGNUP_REJECTED = 'auth/SIGNUP_REJECTED',

  LOGIN = 'auth/LOGIN',
  LOGIN_FULFILLED = 'auth/LOGIN_FULFILLED',
  LOGIN_REJECTED = 'auth/LOGIN_REJECTED',

  LOG_OUT = 'auth/LOG_OUT'
}

export interface ISignupActionType
  extends IPromiseAction<AuthActionTypeKeys.SIGNUP, Promise<{}>> {}

export interface ISignupFulfilledActionType
  extends IPromiseAction<AuthActionTypeKeys.SIGNUP_FULFILLED, {}> {}

export interface ILoginActionType
  extends IPromiseAction<AuthActionTypeKeys.LOGIN, Promise<ILoginResponse>> {}

export interface ILoginFulfilledActionType
  extends IPromiseAction<AuthActionTypeKeys.LOGIN_FULFILLED, ILoginResponse> {}

export interface ILogOutActionType
  extends IPromiseAction<AuthActionTypeKeys.LOG_OUT, {}> {}

export type IAuthActionTypes =
  | ISignupActionType
  | ISignupFulfilledActionType
  | ILoginActionType
  | ILoginFulfilledActionType
  | ILogOutActionType;
