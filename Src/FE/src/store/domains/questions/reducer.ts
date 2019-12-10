import Immutable, { ImmutableObject } from 'seamless-immutable';

import { QuestionsActionTypeKeys, IQuestionsActionTypes } from './actionTypes';
import { IQuestionInitialState } from './types';

const initialState: ImmutableObject<IQuestionInitialState> = Immutable({
  data: [],
  selectedPost: {}
});

const questionsReducer = (state = initialState, action: IQuestionsActionTypes) => {
  switch (action.type) {
    case QuestionsActionTypeKeys.GET_QUESTIONS_PAG_FULFILLED:
      return state.set('data', action.payload);
    
    case QuestionsActionTypeKeys.GET_QUESTION_BY_ID_FULFILLED:
      return state.set('selectedPost', action.payload);

    case QuestionsActionTypeKeys.SET_LIKE_FULFILLED:
      return state.updateIn(['selectedPost', '0'], val => ({...val, downVotes: val.upVotes + 1}))

    case QuestionsActionTypeKeys.SET_DISLIKE_FULFILLED:
      return state.updateIn(['selectedPost', '0'], val => ({...val, downVotes: val.downVotes - 1}))

    default:
      return state;
  }
};

export default questionsReducer;
