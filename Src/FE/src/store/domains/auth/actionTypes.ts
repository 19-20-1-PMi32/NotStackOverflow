import { IPromiseAction } from 'types';

import {} from './types';

export enum AuthActionTypeKeys {
  SIGNUP = 'auth/SIGNUP',
  SIGNUP_FULFILLED = 'auth/SIGNUP_FULFILLED',
  SIGNUP_REJECTED = 'auth/SIGNUP_REJECTED',

  LOGIN = 'auth/LOGIN',
  LOGIN_FULFILLED = 'auth/LOGIN_FULFILLED',
  LOGIN_REJECTED = 'auth/LOGIN_REJECTED',

  GET_USER_DATA = 'auth/GET_USER_DATA',
  GET_USER_DATA_FULFILLED = 'auth/GET_USER_DATA_FULFILLED',
  GET_USER_DATA_REJECTED = 'auth/GET_USER_DATA_REJECTED',

  LOG_OUT = 'auth/LOG_OUT'
}

export interface ISignupActionType
  extends IPromiseAction<AuthActionTypeKeys.SIGNUP, Promise<{}>> {}

export interface ISignupFulfilledActionType
  extends IPromiseAction<AuthActionTypeKeys.SIGNUP_FULFILLED, {}> {}

export interface ILoginActionType
  extends IPromiseAction<AuthActionTypeKeys.LOGIN, Promise<{}>> {}

export interface ILoginFulfilledActionType
  extends IPromiseAction<AuthActionTypeKeys.LOGIN_FULFILLED, {}> {}

export interface IGetUserDataActionType
  extends IPromiseAction<AuthActionTypeKeys.GET_USER_DATA, Promise<{}>> {}

export interface IGetUserDataFulfilledActionType
  extends IPromiseAction<AuthActionTypeKeys.GET_USER_DATA_FULFILLED, {}> {}

export interface ILogOutActionType
  extends IPromiseAction<AuthActionTypeKeys.LOG_OUT, {}> {}

export type IAuthActionTypes =
  | ISignupActionType
  | ISignupFulfilledActionType
  | ILoginActionType
  | ILoginFulfilledActionType
  | IGetUserDataActionType
  | IGetUserDataFulfilledActionType
  | ILogOutActionType;
