import LoginComponent from './Login';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  handleLoginAction,
  IStoreState,
  handleGetUserInfoAction
} from 'store';

const mapStateToProps = (state: IStoreState) => ({

});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      handleLoginAction,
      handleGetUserInfoAction
    },
    dispatch
  );

export const LoginContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(LoginComponent);

export default LoginContainer;