import ProfileComponent from './Profile';

import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux';

import {
  selectUserData,
  IStoreState,
  handleUpdateUserInfoAction,
  handleAddQuestionAction
} from 'store';

const mapStateToProps = (state: IStoreState) => ({
  userData: selectUserData(state)
});

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
      handleUpdateUserInfoAction
    },
    dispatch
  );

export const ProfileContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(ProfileComponent);

export default ProfileContainer;