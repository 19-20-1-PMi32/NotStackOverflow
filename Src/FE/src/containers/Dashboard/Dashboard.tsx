import * as React from 'react';
import { Link } from 'react-router-dom';

import { WarningButton, H3 } from 'components';
import { styled } from 'theme';

import { QuestionItem } from './Item';
import { RouteConsts } from 'consts';

const Wrapper = styled.div`
  max-width: 90%;
  margin: 40px auto;

  .items-wrapper {
    display: flex;
  }

  .header {
    display: flex;
    justify-content: space-between;
    margin-bottom: 30px;
    align-items: flex-end;
  }
`;

const Dashboard = () => {
  return (
    <Wrapper>
      <div className="header"> 
        <H3 className="explore-questions">Explore our Questions</H3>
        <Link to={RouteConsts.AskQuestion}> 
          <WarningButton>Ask Question</WarningButton>
        </Link>
      </div>
      
      <div className="items-wrapper">
        <QuestionItem 
          votesCount={3}
          answerCount={1}
          title="Gaussian expectation of outer product divided by norm (check)"
          userName="nobd=o"
        />
      </div>
    </Wrapper>
  )
};

export default Dashboard;
