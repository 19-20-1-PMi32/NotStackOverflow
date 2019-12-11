import QuestionViewComponent from './QuestionView';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  IStoreState,
  getPostByIdAction,
  selectSelectedPost,
  setLikeAction,
  setDisLikeAction,
  selectUserId,
  addCommentAction
} from 'store';

const mapStateToProps = (state: IStoreState) => ({
  selectedPost: selectSelectedPost(state),
  userId: selectUserId(state)
}); 

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      getPostByIdAction,
      setLikeAction,
      setDisLikeAction,
      addCommentAction
    },
    dispatch
  );

export const QuestionViewContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(QuestionViewComponent);

export default QuestionViewContainer;