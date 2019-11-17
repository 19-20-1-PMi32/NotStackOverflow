using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTOEntities;
using DAL.Entities;

namespace BLL.Mapping
{
    public static class CommentMapper
    {
        public static ICollection<CommentDTO> ToCommentDTOs(this IEnumerable<Comment> comments)
        {
            var commentDTOs = new List<CommentDTO>();

            foreach (var comment in comments)
            {
                commentDTOs.Add(new CommentDTO()
                {
                    Id = comment.Id,
                    PostId = comment.PostId,
                    PosNum = comment.PosNum,
                    Text = comment.Text,
                    //User = comment.User
                });
            }

            return commentDTOs;
        }
    }
}
