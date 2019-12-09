import { IStoreState } from 'store/types';

export interface IUserDataSelect {
  id: number;
  name: string;
  surname: string;
  nickName: string;
  email: string;
  job: string;
}

export const selectUserData = (store: IStoreState): IUserDataSelect => store.user;
