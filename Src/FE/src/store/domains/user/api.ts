import { apiClientService } from 'services';

import { IUpdateUserData } from './types';

export const getUserData = (id: number) => apiClientService.get(`/user/info/${id}`);

export const updateUserData = (id: number, data: IUpdateUserData) => apiClientService.put('/user/update', { data });

export const getUserQuestions = (id: number) => apiClientService.get(`/post/user/${id}`);