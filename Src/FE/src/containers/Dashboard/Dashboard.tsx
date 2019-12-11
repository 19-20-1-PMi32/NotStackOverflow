import * as React from 'react';
import { Link } from 'react-router-dom';

import { WarningButton, H3, QuestionItem } from 'components';
import { styled } from 'theme';

import { RouteConsts } from 'consts';
import { GetAllQuestionsAction, IQuestionInfo } from 'store/domains';

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
  getAllQuestionsAction: GetAllQuestionsAction;
  questions: any;
}

const Dashboard: React.FC<IDashboard> = ({ getAllQuestionsAction, questions }) => {

  React.useEffect(() => {
    getAllQuestionsAction(1)
  }, []);

  console.log(questions)

  return (
    <Wrapper>
      <div className="header"> 
        <H3 className="explore-questions">Explore our Questions</H3>
        <Link to={RouteConsts.AskQuestion}> 
          <WarningButton>Ask Question</WarningButton>
        </Link>
      </div>
      
      <div className="items-wrapper">
        {questions.length > 0 && questions.map((question: IQuestionInfo) => (
           <QuestionItem 
            votesCount={question.upVotes + question.downVotes}
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

export default Dashboard;
