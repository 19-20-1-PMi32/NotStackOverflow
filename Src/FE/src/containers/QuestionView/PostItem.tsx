import * as React from 'react';
import { Formik, Field, Form } from 'formik';

import { DownArrowIcon, H4, P, TextAreaField, Button } from 'components';
import { styled } from 'theme';
import { ICommentView, AddCommentAction } from 'store';

import { CommentItem } from './CommentItem';

const Wrapper = styled.div`

  .top-block {
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
  }

  .form {
    margin-top: 20px;
    margin-left: 80px;
    padding-bottom: 40px;
  }

  .text-area {
    padding-left: 10px;
    padding-top: 10px;
    min-height: 50px;
    resize: vertical;
    height: 50px;
    width: 400px;
  }

  .submit-button {
    margin-top: 10px;
  }

  .all-comments {
    max-height: 200px;
    overflow: auto;
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
  addCommentAction: AddCommentAction;
  el: any;
  userId: number;
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
  downClick,
  addCommentAction,
  el,
  userId
}) => {

  return (
    <Wrapper className={className}>
      <div className="top-block">
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
      </div>
      <div className="all-comments">
        {comments && comments.map(el => (
          <CommentItem
            name={el.user.name}
            text={el.text}
            date={el.dateOfPublish}
            className="comment-item"
          />
        ))}
      </div>
      <Formik
        initialValues={{
          text: ''
        }}
        onSubmit={async (values) => {
          addCommentAction({
            userId,
            posNum: el.postNum,
            dateOfPublish: new Date().toLocaleString(),
            text: values.text,
            postId: el.postId
          })
        }}
      >{({ values }) => (
        <Form className="form">
          <Field
            component={TextAreaField}
            label="Comment"
            name="text"
            placeholder="Enter your comment"
            className="text-area"
          />
          <Button className="submit-button" type="submit" disabled={!values.text}>Send comment</Button>
        </Form>
      )}
      </Formik>
    </Wrapper>
  )
};
