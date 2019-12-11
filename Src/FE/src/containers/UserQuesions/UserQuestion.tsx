import * as React from 'react';
import { Link } from 'react-router-dom';

import { WarningButton, H3, QuestionItem } from 'components';
import { styled } from 'theme';

import { RouteConsts } from 'consts';
import { GetAllQuestionsAction, IQuestionInfo, GetUserPostsAction, IUserDataSelect } from 'store/domains';

const Wrapper = styled.div`
  max-width: 90%;
  margin: 40px auto;

  .items-wrapper {
    display: flex;
    flex-direction: column;
  }

  .header {
    display: flex;
    justify-content: space-between;
    margin-bottom: 30px;
    align-items: flex-end;
  }

  .item-divider {
    margin-top: 10px;
  }
`;

interface IDashboard {
  getUserPostsAction: GetUserPostsAction;
  userData: IUserDataSelect;
  userQuestions: any;
}

const UserQuestion: React.FC<IDashboard> = ({ getUserPostsAction, userData, userQuestions }) => {
  React.useEffect(() => {
    if (userData.id) {
      getUserPostsAction(userData.id);
    }
  }, []);

  return (
    <Wrapper>
      <div className="header"> 
        <H3 className="explore-questions">Your Questions</H3>
      </div>
      
      <div className="items-wrapper">
        {userQuestions && userQuestions.map((question: IQuestionInfo) => (
           <QuestionItem 
            votesCount={question.upVotes - question.downVotes}
            answerCount={0}
            title={question.title}
            userName={question.previewUserDTO.name}
            className="item-divider"
            id={question.id}
          />
        ))}
      </div>
    </Wrapper>
  )
};

export default UserQuestion;
