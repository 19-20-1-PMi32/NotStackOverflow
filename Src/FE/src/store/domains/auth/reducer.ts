import Immutable, { ImmutableObject } from 'seamless-immutable';

import { AuthActionTypeKeys, IAuthActionTypes } from './actionTypes';
import { IAuthInitialState } from './types';

const initialState: ImmutableObject<IAuthInitialState> = Immutable({
  id: 0,
  token: '',
  refreshToken: ''
});

const authReducer = (state = initialState, action: IAuthActionTypes) => {
  switch (action.type) {
    case AuthActionTypeKeys.LOGIN_FULFILLED:
      return state
        .set('id', action.payload.Id)
        .set('token', action.payload.access_token)
        .set('refreshToken', action.payload.refresh_token);

    default:
      return state;
  }
};

export default authReducer;
