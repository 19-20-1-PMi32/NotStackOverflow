import { IPromiseAction } from 'types';

import { ISinglePost } from './types';

export enum QuestionsActionTypeKeys {
  ADD_QUESTION = 'questions/ADD_QUESTION',
  ADD_QUESTION_FULFILLED = 'questions/ADD_QUESTION_FULFILLED',
  ADD_QUESTION_REJECTED = 'questions/ADD_QUESTION_REJECTED',

  GET_QUESTIONS_PAG = 'questions/GET_QUESTIONS_PAG',
  GET_QUESTIONS_PAG_FULFILLED = 'questions/GET_QUESTIONS_PAG_FULFILLED',
  GET_QUESTIONS_PAG_REJECTED = 'questions/GET_QUESTIONS_PAG_REJECTED',

  GET_QUESTION_BY_ID = 'questions/GET_QUESTION_BY_ID',
  GET_QUESTION_BY_ID_FULFILLED = 'questions/GET_QUESTION_BY_ID_FULFILLED',
  GET_QUESTION_BY_ID_REJECTED = 'questions/GET_QUESTION_BY_ID_REJECTED',

  SET_LIKE = 'questions/SET_LIKE',
  SET_LIKE_FULFILLED = 'questions/SET_LIKE_FULFILLED',
  SET_LIKE_REJECTED = 'questions/SET_LIKE_REJECTED',

  SET_DISLIKE = 'questions/SET_DISLIKE',
  SET_DISLIKE_FULFILLED = 'questions/SET_DISLIKE_FULFILLED',
  SET_DISLIKE_REJECTED = 'questions/SET_DISLIKE_REJECTED',
}

export interface ISetLikeActionType
  extends IPromiseAction<QuestionsActionTypeKeys.SET_LIKE, Promise<{}>> {}

export interface ISetLikeFulfilledActionType
  extends IPromiseAction<QuestionsActionTypeKeys.SET_LIKE_FULFILLED, {}> {}

export interface ISetDisLikeActionType
  extends IPromiseAction<QuestionsActionTypeKeys.SET_DISLIKE, Promise<{}>> {}

export interface ISetDisLikeFulfilledActionType
  extends IPromiseAction<QuestionsActionTypeKeys.SET_DISLIKE_FULFILLED, {}> {}

export interface IAddQuestionsActionType
  extends IPromiseAction<QuestionsActionTypeKeys.ADD_QUESTION, Promise<{}>> {}

export interface IAddQuestionsFulfilledActionType
  extends IPromiseAction<QuestionsActionTypeKeys.ADD_QUESTION_FULFILLED, {}> {}

export interface IGetQuestionsActionType
  extends IPromiseAction<QuestionsActionTypeKeys.GET_QUESTIONS_PAG, Promise<{}>> {}

export interface IGetQuestionsFulfilledActionType
  extends IPromiseAction<QuestionsActionTypeKeys.GET_QUESTIONS_PAG_FULFILLED, {}> {}

export interface IGetQuestionByIdActionType
  extends IPromiseAction<QuestionsActionTypeKeys.GET_QUESTION_BY_ID, Promise<ISinglePost>> {}

export interface IGetQuestionByIdFulfilledActionType
  extends IPromiseAction<QuestionsActionTypeKeys.GET_QUESTION_BY_ID_FULFILLED, ISinglePost> {}

export type IQuestionsActionTypes =
  | IAddQuestionsActionType
  | IAddQuestionsFulfilledActionType
  | IGetQuestionsActionType
  | IGetQuestionsFulfilledActionType
  | IGetQuestionByIdActionType
  | IGetQuestionByIdFulfilledActionType
  | ISetLikeActionType
  | ISetLikeFulfilledActionType
  | ISetDisLikeActionType
  | ISetDisLikeFulfilledActionType;
