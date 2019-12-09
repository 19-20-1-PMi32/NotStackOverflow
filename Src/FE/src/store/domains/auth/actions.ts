import { push } from 'connected-react-router';

import { apiClientService } from 'services';
import { IThunk } from 'types';

import {
  AuthActionTypeKeys,
  ISignupActionType,
  ILoginActionType,
  ILogOutActionType
} from './actionTypes';
import * as api from './api';
import { ISignupData } from './types';
import { selectRefreshToken, selectUserToken } from './selectors';

export const setToken = (val: string, refreshToken: string) => {
  window.localStorage.setItem('AUTH_TOKEN', val);
  window.localStorage.setItem('REFRESH_TOKEN', refreshToken);
  apiClientService.setDefaultHeaders('Authorization', `Bearer ${val}`);
};

export type SignupAction = (data: ISignupData) => ISignupActionType;
export type HandleSignupAction = (data: ISignupData) => IThunk<void>;

export type LoginAction = (email: string, password: string) => ILoginActionType;
export type HandleLoginAction = (email: string, password: string) => IThunk<void>;

export type HandleInitAction = () => IThunk<void>;
export type LogOutAction = () => ILogOutActionType;
export type HandleLogOutAction = () => IThunk<void>;

export const signupAction: SignupAction = (data) => ({
  type: AuthActionTypeKeys.SIGNUP,
  payload: api.signup(data)
})

export const loginAction: LoginAction = (email, password) => ({
  type: AuthActionTypeKeys.LOGIN,
  payload: api.login(email, password)
})

export const logOutAction: LogOutAction = () => ({
  type: AuthActionTypeKeys.LOG_OUT,
  payload: {}
});

export const handleLogOutAction: HandleLogOutAction = () => (dispatch) => {
  dispatch(logOutAction());
  window.localStorage.removeItem('AUTH_TOKEN');
}

export const handleSignupAction: HandleSignupAction = (
  data
) => async dispatch => {
  try {
    await dispatch(signupAction(data));
    dispatch(push('/auth'));
  } catch {
    alert('Failed signup');
  }
}

export const handleLoginAction: HandleLoginAction = (email, password) => async (dispatch, getState) => {
  await(dispatch(loginAction(email, password)));

  const state = getState();
  const userToken = selectUserToken(state);
  const refreshToken = selectRefreshToken(state);

  setToken(userToken, refreshToken);
}
