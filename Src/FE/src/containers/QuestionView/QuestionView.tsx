import * as React from 'react';
import { withRouter, RouteComponentProps } from 'react-router-dom';

import { styled } from 'theme';

import { QuestionItem } from './PostItem';
import { GetPostByIdAction, IFullQuestionView, SetDisLikeAction, SetLikeAction, AddCommentAction } from 'store/domains';

const Wrapper = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 40px;

  .comment-item {
    margin-top: 10px;
    margin-left: 80px;
  }
`;

interface IQuestionView extends RouteComponentProps<{ id: string }> {
  getPostByIdAction: GetPostByIdAction;
  selectedPost: any;
  setDisLikeAction: SetDisLikeAction;
  setLikeAction: SetLikeAction;
  userId: number;
  addCommentAction: AddCommentAction;
}

const QuestionView: React.FC<IQuestionView> = ({ 
  getPostByIdAction, 
  match, 
  selectedPost, 
  setDisLikeAction,  
  setLikeAction,
  userId,
  addCommentAction
}) => {
  const postId = match.params.id;

  React.useEffect(() => {
    if (postId) {
      getPostByIdAction(+postId);
    }
  }, []);

  if (selectedPost[0]) {
    console.log('upVotes', selectedPost[0].upVotes)
  console.log('downVotes', selectedPost[0].downVotes)
  }
  

  return (
    <Wrapper>
      {selectedPost && Object.values(selectedPost).map((el: any) => (
        <QuestionItem
          title={el.title}
          text={el.text}
          rating={el.downVotes + el.upVotes}
          date={el.dateOfPublish}
          name={el.user.name}
          comments={el.comments}
          el={el}
          userId={userId}
          upClick={() => {
            setLikeAction(el.id, userId, el.postNum);
          }}
          downClick={() => {
            setDisLikeAction(el.id, userId, el.postNum);
          }}
          className="question-item"
          addCommentAction={addCommentAction}
        />
      ))}
    </Wrapper>
  )
};

export default withRouter(QuestionView);
