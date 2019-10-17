using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOEntities;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        PostDTO CreatePost(PostDTO postDTO);

        PostDTO UpdatePost(PostDTO postDTO);

        void RemovePost(int id);

        PostDTO GetPostById(int id);


    }
}
