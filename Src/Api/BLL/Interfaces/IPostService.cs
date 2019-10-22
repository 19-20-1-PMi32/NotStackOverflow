using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOEntities;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        PostDTO CreatePost(PostDTO postDTO);

        int UpdateDownVotes(int id);

        int UpdateUpVotes(int id);

        string UpdateText(int id, string text);

        int UpdateViews(int id);

        void RemovePost(int id);

        PostDTO GetPostById(int id);

        IEnumerable<PostDTO> GetPostsWithComments(int postId, int startFrom, int amount);

        IEnumerable<PostDTO> GetPostList(int startFrom, int amount);
    }
}
