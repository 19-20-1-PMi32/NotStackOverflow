import { IPromiseAction } from 'types';

import { IUserDataResponse } from './types';

export enum UserActionTypeKeys {
  GET_USER_INFO = 'user/GET_USER_INFO',
  GET_USER_INFO_FULFILLED = 'user/GET_USER_INFO_FULFILLED',
  GET_USER_INFO_REJECTED = 'user/GET_USER_INFO_REJECTED',
}

export interface IGetUserInfoActionType
  extends IPromiseAction<UserActionTypeKeys.GET_USER_INFO, Promise<IUserDataResponse>> {}

export interface IGetUserInfoFulfilledActionType
  extends IPromiseAction<UserActionTypeKeys.GET_USER_INFO_FULFILLED, IUserDataResponse> {}

export type IUserActionTypes =
  | IGetUserInfoActionType
  | IGetUserInfoFulfilledActionType;
