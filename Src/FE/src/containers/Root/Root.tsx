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
import UserQuestions from '../UserQuesions';
import QuestionViewContainer from '../QuestionView';
import { IUserDataSelect, HandleInitAction, HandleLogOutAction } from 'store/domains';

const Wrapper = styled.div`
  min-height: 100vh;
  width: 100%;
`;

interface IRoot {
  userData: IUserDataSelect;
  handleInitAction: HandleInitAction;
  handleLogOutAction: HandleLogOutAction;
}

const Root: React.FC<IRoot> = ({ userData, handleInitAction, handleLogOutAction }) => {
  
  React.useEffect(() => {
    handleInitAction()
  }, [])

  return (
    <Wrapper>
      <NavBarMenu userData={userData} handleLogOutAction={handleLogOutAction}/>
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
        <Route
          exact={true}
          path={RouteConsts.ProfileQuestions}
          component={UserQuestions}
        />
        <Route
          exact={true}
          path={RouteConsts.QuestionItem}
          component={QuestionViewContainer}
        />
      </Switch>
    </Wrapper>
  );
};

export default Root;
