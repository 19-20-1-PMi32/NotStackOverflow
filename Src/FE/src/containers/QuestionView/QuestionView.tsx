import * as React from 'react';
import { withRouter, RouteComponentProps } from 'react-router-dom';

import { styled } from 'theme';

import { QuestionItem } from './PostItem';
import { GetPostByIdAction, IFullQuestionView, SetDisLikeAction, SetLikeAction } from 'store/domains';

const Wrapper = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 40px;

  .question-item {
  }

  .comment-item {
    margin-left: 80px;
  }
`;

interface IQuestionView extends RouteComponentProps<{ id: string }> {
  getPostByIdAction: GetPostByIdAction;
  selectedPost: any;
  setDisLikeAction: SetDisLikeAction;
  setLikeAction: SetLikeAction;
  userId: number;
}

const QuestionView: React.FC<IQuestionView> = ({ 
  getPostByIdAction, 
  match, 
  selectedPost, 
  setDisLikeAction,  
  setLikeAction,
  userId
}) => {
  const postId = match.params.id;

  React.useEffect(() => {
    if (postId) {
      getPostByIdAction(+postId, 1);
    }
  }, []);

  return (
    <Wrapper>
      {selectedPost && Object.values(selectedPost).map((el: any) => (
        <QuestionItem
          title={el.title}
          text={el.text}
          rating={el.upVotes + el.downVotes}
          date={el.dateOfPublish}
          name={el.user.name}
          comments={el.comments}
          upClick={() => {
            setLikeAction(el.id, userId);
          }}
          downClick={() => {
            setDisLikeAction(el.id, userId);
          }}
          className="question-item"
        />
      ))}
    </Wrapper>
  )
};

export default withRouter(QuestionView);
