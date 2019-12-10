import { ConnectedRouter } from 'connected-react-router';

import {
  IAuthState,
  IUserState,
  IQuestionState
} from './domains';

export interface IStoreState {
  router: ConnectedRouter;
  auth: IAuthState;
  user: IUserState;
  questions: IQuestionState;
}
