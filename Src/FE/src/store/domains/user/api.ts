import { apiClientService } from 'services';

export const getUserData = (id: number) => apiClientService.get(`/user/info/${id}`);
