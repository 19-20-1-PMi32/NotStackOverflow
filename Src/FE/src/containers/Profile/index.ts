import ProfileComponent from './Profile';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  selectUserData,
  IStoreState
} from 'store';

const mapStateToProps = (state: IStoreState) => ({
  userData: selectUserData(state)
});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
    },
    dispatch
  );

export const ProfileContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(ProfileComponent);

export default ProfileContainer;