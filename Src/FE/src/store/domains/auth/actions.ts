import { push } from 'connected-react-router';

import { apiClientService } from 'services';
import { IThunk } from 'types';

import {
  AuthActionTypeKeys,
  ISignupActionType,
  ILoginActionType,
  IGetUserDataActionType,
  ILogOutActionType
} from './actionTypes';
import * as api from './api';
import { ISignupData } from './types';

export const setToken = (val: string) => {
  window.localStorage.setItem('AUTH_TOKEN', val);
  apiClientService.setDefaultHeaders('Authorization', `Bearer ${val}`);
};

export type SignupAction = (data: ISignupData) => ISignupActionType;
export type HandleSignupAction = (data: ISignupData) => IThunk<void>;

export type LoginAction = (email: string, password: string) => ILoginActionType;
export type HandleLoginAction = (email: string, password: string) => IThunk<void>;

export type GetUserData = () => IGetUserDataActionType;
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
