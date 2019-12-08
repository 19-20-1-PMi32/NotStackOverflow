using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOEntities;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        CommentDTO CreateComment(CommentDTO commentDTO);

        string UpdateComment(int id, string text);

        void RemoveComment(int id);

    }
}
