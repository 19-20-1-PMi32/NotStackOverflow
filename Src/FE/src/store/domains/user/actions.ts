import { push } from 'connected-react-router';

import { apiClientService } from 'services';
import { IThunk } from 'types';

import {
  IGetUserInfoActionType,
  UserActionTypeKeys,
  IUpdateUserInfoActionType,
  IGetUserPostsActionType
} from './actionTypes';
import * as api from './api';

import { selectUserId } from './selectors';
import { selectAuthUserId } from '../auth';
import { IUpdateUserData } from './types';

export type GetUserInfoAction = (userId: number) => IGetUserInfoActionType;
export type HandleGetUserInfoAction = () => IThunk<void>;

export type UpdateUserInfoAction = (userId: number, data: IUpdateUserData) => IUpdateUserInfoActionType;
export type HandleUpdateUserInfoAction = (data: IUpdateUserData) => IThunk<void>;

export type GetUserPostsAction = (userId: number) => IGetUserPostsActionType;

export const getUserPostsAction: GetUserPostsAction = (userId) => ({
  type: UserActionTypeKeys.GET_USER_POSTS,
  payload: api.getUserQuestions(userId)
})

export const getUserInfoAction: GetUserInfoAction = (userId) => ({
  type: UserActionTypeKeys.GET_USER_INFO,
  payload: api.getUserData(userId)
});

export const updateUserInfoAction: UpdateUserInfoAction = (userId, data) => ({
  type: UserActionTypeKeys.UPDATE_USER_INFO,
  payload: api.updateUserData(userId, data)
});

export const handleGetUserInfoAction: HandleGetUserInfoAction = () => (dispatch, getState) => {
  const state = getState();

  dispatch(getUserInfoAction(selectAuthUserId(state)))
}

export const handleUpdateUserInfoAction: HandleUpdateUserInfoAction = (data) => async (dispatch, getState) => {
  const state = getState();
  const userId = selectUserId(state);

  try {
    await dispatch(updateUserInfoAction(userId, { id: userId, ...data}));
    alert('Succesfully update')
  } catch {
    alert('Error')
  }
}