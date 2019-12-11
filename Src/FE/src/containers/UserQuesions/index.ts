import UserQuestionsComponent from './UserQuestion';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  IStoreState,
  getUserPostsAction,
  selectUserData,
  selectUserPosts
  
} from 'store';

const mapStateToProps = (state: IStoreState) => ({
  userData: selectUserData(state),
  userQuestions: selectUserPosts(state)
});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      getUserPostsAction
    },
    dispatch
  );

export const UserQuestionsContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(UserQuestionsComponent);

export default UserQuestionsContainer;