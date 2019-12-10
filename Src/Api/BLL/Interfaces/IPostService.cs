using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOEntities;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        PostDTO CreatePost(CreatePostDTO postDTO);

        int UpdateDownVotes(int id);

        int UpdateUpVotes(int id);

        string UpdateText(int id, string text);

        int UpdateViews(int id);

        void RemovePost(int id);

        PostDTO GetPostById(int id);

        IEnumerable<PostDTO> GetPostsWithComments(int postId);

        IEnumerable<PreviewPostDTO> GetPostList(int amount, string orderBy, out int pageCount);

        IEnumerable<PreviewPostDTO> GetUsersPostById(int userId);

        int SetLike(VoteDTO voteDto);

        int SetDislike(VoteDTO voteDto);
    }
}
