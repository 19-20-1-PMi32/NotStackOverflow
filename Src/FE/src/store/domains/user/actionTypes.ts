import { IPromiseAction } from 'types';

import { IUserDataResponse, IUpdateUserData } from './types';

import { IQuestionInfo } from '../questions';
import { ILogOutActionType } from '../auth';

export enum UserActionTypeKeys {
  GET_USER_INFO = 'user/GET_USER_INFO',
  GET_USER_INFO_FULFILLED = 'user/GET_USER_INFO_FULFILLED',
  GET_USER_INFO_REJECTED = 'user/GET_USER_INFO_REJECTED',

  UPDATE_USER_INFO = 'user/UPDATE_USER_INFO',
  UPDATE_USER_INFO_FULFILLED = 'user/UPDATE_USER_INFO_FULFILLED',
  UPDATE_USER_INFO_REJECTED = 'user/UPDATE_USER_INFO_REJECTED',

  GET_USER_POSTS = 'user/GET_USER_POSTS',
  GET_USER_POSTS_FULFILLED = 'user/GET_USER_POSTS_FULFILLED',
  GET_USER_POSTS_REJECTED = 'user/GET_USER_POSTS_REJECTED',
}

export interface IGetUserInfoActionType
  extends IPromiseAction<UserActionTypeKeys.GET_USER_INFO, Promise<IUserDataResponse>> {}

export interface IGetUserInfoFulfilledActionType
  extends IPromiseAction<UserActionTypeKeys.GET_USER_INFO_FULFILLED, IUserDataResponse> {}

export interface IUpdateUserInfoActionType
  extends IPromiseAction<UserActionTypeKeys.UPDATE_USER_INFO, Promise<{}>, IUpdateUserData> {}

export interface IUpdateUserInfoFulfilledActionType
  extends IPromiseAction<UserActionTypeKeys.UPDATE_USER_INFO_FULFILLED, {}, IUpdateUserData> {}

export interface IGetUserPostsActionType
  extends IPromiseAction<UserActionTypeKeys.GET_USER_POSTS, Promise<IQuestionInfo[]>> {}

export interface IGetUserPostsFulfilledActionType
  extends IPromiseAction<UserActionTypeKeys.GET_USER_POSTS_FULFILLED, IQuestionInfo[]> {}

export type IUserActionTypes =
  | IGetUserInfoActionType
  | IGetUserInfoFulfilledActionType
  | IUpdateUserInfoActionType
  | IUpdateUserInfoFulfilledActionType
  | IGetUserPostsActionType
  | IGetUserPostsFulfilledActionType
  | ILogOutActionType;
