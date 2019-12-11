import Immutable, { ImmutableObject } from 'seamless-immutable';

import { QuestionsActionTypeKeys, IQuestionsActionTypes } from './actionTypes';
import { IQuestionInitialState } from './types';

const initialState: ImmutableObject<IQuestionInitialState> = Immutable({
  data: [],
  pageCount: 0,
  selectedPost: {},
});

const questionsReducer = (state = initialState, action: IQuestionsActionTypes) => {
  switch (action.type) {
    case QuestionsActionTypeKeys.GET_QUESTIONS_PAG_FULFILLED:
      return state.set('data', action.payload.posts).set('pageCount', action.payload.pageCount);
    
    case QuestionsActionTypeKeys.GET_QUESTION_BY_ID_FULFILLED:
      return state.set('selectedPost', action.payload)

    case QuestionsActionTypeKeys.SET_LIKE_FULFILLED: {
      const postId = action.meta as any;

      return state.updateIn(['selectedPost', postId], val => ({...val, upVotes: val.upVotes + 1}))
    }

    case QuestionsActionTypeKeys.SET_DISLIKE_FULFILLED: {
      const postId = action.meta as any;

      return state.updateIn(['selectedPost', postId], val => ({...val, downVotes: val.downVotes - 1}))
    }

    case QuestionsActionTypeKeys.ADD_COMMENT_FULFILLED: {
      const meta = action.meta as any;

      return state.updateIn(['selectedPost', meta.posNum, 'comments'], val => val.concat(meta))
    }

    default:
      return state;
  }
};

export default questionsReducer;
