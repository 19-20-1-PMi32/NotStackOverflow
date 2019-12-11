import { IStoreState } from 'store/types';

export const selectAuthUserId = (state: IStoreState) => state.auth.id;

export const selectUserToken = (state: IStoreState) => state.auth.token;

export const selectRefreshToken = (state: IStoreState) => state.auth.refreshToken;
