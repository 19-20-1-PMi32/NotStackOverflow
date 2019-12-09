import { push } from 'connected-react-router';

import { apiClientService } from 'services';
import { IThunk } from 'types';

import {
  IGetUserInfoActionType,
  UserActionTypeKeys
} from './actionTypes';
import * as api from './api';

import {  } from './selectors';
import { selectUserId } from '../auth';

export type GetUserInfoAction = (userId: number) => IGetUserInfoActionType;
export type HandleGetUserInfoAction = () => IThunk<void>;

export const getUserInfoAction: GetUserInfoAction = (userId) => ({
  type: UserActionTypeKeys.GET_USER_INFO,
  payload: api.getUserData(userId)
})

export const handleGetUserInfoAction: HandleGetUserInfoAction = () => (dispatch, getState) => {
  const state = getState();

  dispatch(getUserInfoAction(selectUserId(state)))
}
