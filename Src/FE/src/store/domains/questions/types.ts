import { ImmutableObject, ImmutableArray } from 'seamless-immutable';

export interface IQuestionData {
  postNum: number;
  text: string;
  title: string;
  dateOfPublish: string;
  userId: number;
}

export interface IQuestionsPagPayload {
  posts: [],
  pageCount: number;
}

export interface IQuestionInfo {
  id: number;
  text: string;
  title: string;
  upVotes: number;
  downVotes: number;
  viewed: number;
  previewUserDTO: {
      id: number;
      nickName: string;
      name: string;
      surname: string;
  };
}

interface IUserDTO  {
  id: number;
  nickName: string;
  name: string;
  surname: string;
}

export interface ICommentView {
  id: number;
  postId: number;
  posNum: number;
  dateOfPublish: string;
  text: string;
  userId: number;
  user: IUserDTO;
}

export interface IFullQuestionView {
  id: number;
  postId: number;
  postNum: number;
  upVotes: number;
  downVotes: number;
  text: string;
  title: string;
  viewed: number;
  dateOfPublish: string;
  postTags: ICommentView[],
  comments: [],
  user: IUserDTO;
}

export interface ISinglePost {
  [key: string]: IFullQuestionView
}

export interface IQuestionInitialState {
  data: IQuestionInfo[];
  selectedPost: ISinglePost;
  pageCount: number;
}

export interface IAddComment {
	posNum: number;
	dateOfPublish: string;
	text: string;
	userId: number;
	postId: number;
}

export interface IQuestionState extends ImmutableObject<IQuestionInitialState> {}
