import { apiClientService } from 'services';

import { IQuestionData, IFullQuestionView } from './types';

export const addQuestion = (data: IQuestionData) => apiClientService.post('/post/create', { data });

export const getPostPagination = (page: number) => apiClientService.get(`/post/all/${page}`);

export const getPostById = (postId: number, page: number) => 
  apiClientService.get(`/post/issue/${postId}/${page}`).then(res => {
    const obj: {[key: string]: IFullQuestionView} = {}

    res.map((el: IFullQuestionView) => {
      obj[el.postNum] = el;
    })

    return obj;
  })

export const likePost = (postId: number, userId: number) => apiClientService.put('/post/vote', {
  data: {
    postId,
    userId
  }
});

export const disLikePost = (postId: number, userId: number) => apiClientService.put('/post/dislike', {
  data: {
    postId,
    userId
  }
});
