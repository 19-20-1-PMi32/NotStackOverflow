import RootComponent from './Root';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  selectUserData,
  IStoreState,
  handleInitAction
} from 'store';

const mapStateToProps = (state: IStoreState) => ({
  userData: selectUserData(state)
});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      handleInitAction
    },
    dispatch
  );

export const RootContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(RootComponent);

export default RootContainer;