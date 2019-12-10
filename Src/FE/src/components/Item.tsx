import * as React from 'react';
import { Link } from 'react-router-dom';

import { styled } from 'theme';

const SubItemWrapper = styled.div`
  height: 38px;
  min-width: 38px;
  max-width: 42px;
  margin: 5px;

  display: inline-flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-around;

  color: ${({ theme }) => theme.color.grey}

  .count {
    font-size: 17px;
  }

  .title {
    font-size: 11px;
  }
`;

interface ISubItem {
  count: number;
  title: string;
}

const SubItem: React.FC<ISubItem> = ({ title, count }) => {
  return (
    <SubItemWrapper>
      <div className="count">
        <span>{count}</span>
      </div>
      <div className="title">{title}</div>
    </SubItemWrapper>
  );
}

const Wrapper = styled.div`
  width: 100%;
  height: 93px;
  padding: 12px 8px;

  border-radius: 4px;
  border: 1px solid ${({ theme }) => theme.color.grey};

  display: flex;
  cursor: pointer;

  .votes {
    display: inline-flex;
  }

  .info {
    margin-left: 10px;
    display: flex;
    justify-content: space-between;
    flex-direction: column;
  }

  .info-title {
    font-size: 17px;
    font-weight: 400;
    color: ${({ theme }) => theme.color.primary};
  }

  .info-username {
    font-size: 13px;
    color: ${({ theme }) => theme.color.black};
  }
`;

interface IQuestionItem {
  votesCount: number;
  answerCount: number;
  title: string;
  userName: string;
  className?: string;
  id: number;
}

export const QuestionItem: React.FC<IQuestionItem> = ({
  votesCount,
  answerCount,
  title,
  userName,
  className,
  id
}) => {
  return (
    <Link to={`/question/${id}/info`}>
    <Wrapper className={className}>
      <div className="votes">
        <SubItem title={"votes"} count={votesCount}/>
        <SubItem title={"answer"} count={answerCount}/>
      </div>
      <div className="info">
        <span className="info-title">{title}</span>
        <span className="info-username">Created by: {userName}</span>
      </div>
    </Wrapper>
    </Link>
  )
};
