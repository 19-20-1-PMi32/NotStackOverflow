import { History } from 'history';

import { connectRouter } from 'connected-react-router';
import { combineReducers } from 'redux-seamless-immutable';

import authReducer from './domains/auth/reducer';
import userReducer from './domains/user/reducer';
 
const createRootReducer = (history: History) => combineReducers({
  router: connectRouter(history),
  auth: authReducer,
  user: userReducer
});

export default createRootReducer;
