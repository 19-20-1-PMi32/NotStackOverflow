import Immutable, { ImmutableObject } from 'seamless-immutable';

import { UserActionTypeKeys, IUserActionTypes } from './actionTypes';
import { IUserInitialState } from './types';

const initialState: ImmutableObject<IUserInitialState> = Immutable({
  id: 0,
  name: '',
  surname: '',
  nickName: '',
  email: '',
  job: '',
  questions: []
});

const authReducer = (state = initialState, action: IUserActionTypes) => {
  switch (action.type) {
    case UserActionTypeKeys.GET_USER_INFO_FULFILLED:
      return state.merge(action.payload);

    case UserActionTypeKeys.GET_USER_POSTS_FULFILLED:
      return state.set('questions', action.payload);

    default:
      return state;
  }
};

export default authReducer;
