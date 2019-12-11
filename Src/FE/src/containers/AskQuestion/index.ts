import AskQuestionComponent from './AskQuestion';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  IStoreState,
  handleAddQuestionAction,
  selectUserId
} from 'store';

const mapStateToProps = (state: IStoreState) => ({
  userId: selectUserId(state)
});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      handleAddQuestionAction
    },
    dispatch
  );

export const AskQuestionContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(AskQuestionComponent);

export default AskQuestionContainer;