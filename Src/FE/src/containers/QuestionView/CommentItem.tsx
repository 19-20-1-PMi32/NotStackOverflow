import * as React from 'react';

import { styled } from 'theme';

import { QuestionItem } from './PostItem';

const Wrapper = styled.div`
  width: 500px;
  min-height: 50px;

  display: flex;
  flex-direction: column;

  border-top: 1px solid ${({ theme }) => theme.color.primary};
  border-bottom: 1px solid ${({ theme }) => theme.color.primary};
  padding: 10px;

  font-size: 14px;

  .comment-title {
    margin-bottom: 6px;
  }

  .comment-text {
    word-break: break-all;
  }
`;

interface ICommentItem {
  name: string;
  text: string;
  date: string;
  className: string;
}

export const CommentItem: React.FC<ICommentItem> = ({
  name,
  text,
  date,
  className
}) => {
  return (
    <Wrapper className={className}>
      <div className="comment-title">{name}, commented on {date}</div>
      <div className="comment-text">{text}</div>
    </Wrapper>
  )
}