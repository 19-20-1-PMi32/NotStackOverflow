import { apiClientService } from 'services';

import { ISignupData } from './types';

export const login = (email: string, password: string) =>
  apiClientService.post('/account/token', {
    data: `grant_type=password&email=${email}&password=${password}`
  });

export const signup = (data: ISignupData) =>
  apiClientService.post('/user/register', { data: data });
