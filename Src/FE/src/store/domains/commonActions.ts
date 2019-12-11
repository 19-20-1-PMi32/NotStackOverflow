import jwt_decode from 'jwt-decode';

import { getUserInfoAction } from 'store';
import { IThunk } from 'types';
import { apiClientService } from 'services';

type HandleInitAction = () => IThunk<void>;

export const handleInitAction: HandleInitAction = () => async (dispatch, getState) => {
  const token = window.localStorage.getItem('AUTH_TOKEN');
  const refreshToken = window.localStorage.getItem('REFRESH_TOKEN');
  
  if (token) {
    apiClientService.setDefaultHeaders('Authorization', `Bearer ${token}`);
    const decodedToken = await jwt_decode(token) as { Id: number };

    await dispatch(getUserInfoAction(decodedToken.Id));
  }
}