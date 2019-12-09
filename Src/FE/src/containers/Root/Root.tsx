import * as React from 'react';
import { Switch, Route } from 'react-router';

import { NavBarMenu } from 'components';
import { styled } from 'theme'
import { RouteConsts } from 'consts';

import LoginContainer from '../Login';
import SignUpContainer from '../SignUp';
import DashboardContainer from '../Dashboard';
import AskQuestionContainer from '../AskQuestion';
import ProfileContainer from '../Profile';
import { IUserDataSelect, HandleInitAction } from 'store/domains';

const Wrapper = styled.div`
  min-height: 100vh;
  width: 100%;
`;

interface IRoot {
  userData: IUserDataSelect;
  handleInitAction: HandleInitAction;
}

const Root: React.FC<IRoot> = ({ userData, handleInitAction }) => {
  
  React.useEffect(() => {
    handleInitAction()
  }, [])

  return (
    <Wrapper>
      <NavBarMenu userData={userData}/>
      <Switch>
        <Route
          exact={true}
          path={RouteConsts.Login}
          component={LoginContainer}
        />
        <Route
          exact={true}
          path={RouteConsts.SignUp}
          component={SignUpContainer}
        />
        <Route
          exact={true}
          path={RouteConsts.Dashboard}
          component={DashboardContainer}
        />
        <Route
          exact={true}
          path={RouteConsts.AskQuestion}
          component={AskQuestionContainer}
        />
        <Route
          exact={true}
          path={RouteConsts.Profile}
          component={ProfileContainer}
        />
      </Switch>
    </Wrapper>
  );
};

export default Root;
