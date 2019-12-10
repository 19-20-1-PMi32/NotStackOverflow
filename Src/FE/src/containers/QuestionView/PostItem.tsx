import * as React from 'react';

import { DownArrowIcon, H4, P } from 'components';
import { styled } from 'theme';
import { ICommentView } from 'store/domains';

import { CommentItem } from './CommentItem';

const Wrapper = styled.div`
  width: 600px;
  min-height: 400px;

  display: flex;
  padding-bottom: 20px;

  .left-side {
    height: 100%;
    width: 15%;

    display: flex;
    flex-direction: column;
    align-items: center;

    .up-icon {
      width: 30px;
      height: 30px;
      transform: rotate(180deg);
      margin-top: 25px;
      margin-bottom: 10px;
      cursor: pointer;

      :hover {
        fill: ${({ theme }) => theme.color.primary};
      }
    }
  
    .down-icon {
      margin-top: 10px;
      width: 30px;
      height: 30px;
      cursor: pointer;

      :hover {
        fill: ${({ theme }) => theme.color.red};
      }
    }

    .rating {
      font-size: 22px;
    }
  }

  .right-side {
    width: 85%;
    padding-top: 20px;
    padding-left: 20px;
    border: 1px solid ${({ theme }) => theme.color.primary};


    .title {
      font-size: 26px;
      margin-bottom: 10px;
    }

    .text {
      margin-top: 20px;
      word-break: break-all;
      padding-right: 20px;
    }
  }
`;

interface IQuestionView {
  title: string;
  text: string;
  rating: number;
  date: string;
  name: string;
  comments: ICommentView[];
  className: string;
  upClick: () => void;
  downClick: () => void;
}

export const QuestionItem: React.FC<IQuestionView> = ({
  title,
  text,
  rating,
  date,
  name,
  className,
  comments,
  upClick,
  downClick
}) => {

  return (
    <>
      <Wrapper className={className}>
        <div className="left-side">
          <DownArrowIcon className="up-icon" onClick={upClick}/>
          <H4 className="rating">{rating}</H4>
          <DownArrowIcon className="down-icon" onClick={downClick}/>
        </div>
        <div className="right-side">
          <H4 className="title">{title}</H4>
          <P>Created at: {date} by {name}</P>
          <div className="text">{text}</div>
        </div>
      </Wrapper>
      {comments && comments.map(el => (
        <CommentItem
          name={el.user.name}
          text={el.text}
          date={el.dateOfPublish}
          className="comment-item"
        />
      ))}
    </>
  )
};
