import { push } from 'connected-react-router';

import { IThunk } from 'types';

import {
  IAddQuestionsActionType,
  QuestionsActionTypeKeys,
  IGetQuestionsActionType,
  IGetQuestionByIdActionType,
  ISetDisLikeActionType,
  ISetLikeActionType,
  IAddCommentActiontype
} from './actionTypes';
import * as api from './api';

import {} from './selectors';
import { selectAuthUserId } from '../auth';
import { IQuestionData, IAddComment } from './types';

export type AddQuestionAction = (data: IQuestionData) => IAddQuestionsActionType;
export type HandleAddQuestionAction = (data: IQuestionData) => IThunk<void>;

export type GetAllQuestionsAction = (page: number) => IGetQuestionsActionType;

export type GetPostByIdAction = (postId: number) => IGetQuestionByIdActionType;
export type SetLikeAction = (postId: number, userId: number, postNum: number) => ISetLikeActionType;
export type SetDisLikeAction = (postId: number, userId: number, postNum: number) => ISetDisLikeActionType;

export type AddCommentAction = (data: IAddComment) => IAddCommentActiontype;

export const setLikeAction: SetLikeAction = (postId, userId, postNum) => ({
  type: QuestionsActionTypeKeys.SET_LIKE,
  payload: api.likePost(postId, userId),
  meta: postNum
});

export const addCommentAction: AddCommentAction = (data) => ({
  type: QuestionsActionTypeKeys.ADD_COMMENT,
  payload: api.addComment(data),
  meta: data
});

export const setDisLikeAction: SetDisLikeAction = (postId, userId, postNum) => ({
  type: QuestionsActionTypeKeys.SET_DISLIKE,
  payload: api.disLikePost(postId, userId),
  meta: postNum
});

export const addQuestionAction: AddQuestionAction = (data) => ({
  type: QuestionsActionTypeKeys.ADD_QUESTION,
  payload: api.addQuestion(data)
});

export const getAllQuestionsAction: GetAllQuestionsAction = (page) => ({
  type: QuestionsActionTypeKeys.GET_QUESTIONS_PAG,
  payload: api.getPostPagination(page)
});

export const getPostByIdAction: GetPostByIdAction = (postId) => ({
  type: QuestionsActionTypeKeys.GET_QUESTION_BY_ID,
  payload: api.getPostById(postId)
});

export const handleAddQuestionAction: HandleAddQuestionAction = (data) => (dispatch, getState) => {
  dispatch(addQuestionAction(data));
};