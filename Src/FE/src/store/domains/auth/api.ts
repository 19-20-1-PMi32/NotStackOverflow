import { apiClientService } from 'services';

import { ISignupData } from './types';

export const login = (email: string, password: string) =>
  apiClientService.post('/account/token', {
    data: {
      email,
      password
    }
  });

export const signup = (data: ISignupData) =>
  apiClientService.post('/user/register', { data });
