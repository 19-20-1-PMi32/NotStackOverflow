import { IStoreState } from 'store/types';

export const selectQuestions = (state: IStoreState) => state.questions.data;

export const selectSelectedPost = (state: IStoreState) => state.questions.selectedPost;
