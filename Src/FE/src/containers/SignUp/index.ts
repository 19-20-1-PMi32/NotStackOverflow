import SignupComponent from './SignUp';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  handleSignupAction,
  IStoreState
} from 'store';

const mapStateToProps = (state: IStoreState) => ({

});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      handleSignupAction
    },
    dispatch
  );

export const SignupContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(SignupComponent);

export default SignupContainer;