import Immutable, { ImmutableObject } from 'seamless-immutable';

import { AuthActionTypeKeys, IAuthActionTypes } from './actionTypes';
import { IAuthInitialState } from './types';

const initialState: ImmutableObject<IAuthInitialState> = Immutable({
});

const authReducer = (state = initialState, action: IAuthActionTypes) => {
  switch (action.type) {

    default:
      return state;
  }
};

export default authReducer;
