import DashboardComponent from './Dashboard';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  IStoreState,
  getAllQuestionsAction,
  selectQuestions
} from 'store';

const mapStateToProps = (state: IStoreState) => ({
  questions: selectQuestions(state)
});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      getAllQuestionsAction
    },
    dispatch
  );

export const DashboardContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(DashboardComponent);

export default DashboardContainer;