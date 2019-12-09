using System;
using System.Collections.Generic;
using System.Linq;
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
                    if (comment.User == null)
                    {
                        commentDTOs.Add(new CommentDTO()
                        {
                            Id = comment.Id,
                            PostId = comment.PostId,
                            PosNum = comment.PosNum,
                            Text = comment.Text,
                            //User = user
                        });
                        break;
                    }

                    var user = new UserDTO() 
                    {
                        Id = comment.UserId,
                        Name = comment.User.Name,
                        Surname = comment.User.Surname,
                        NickName = comment.User.NickName,
                    };
                    
                    commentDTOs.Add(new CommentDTO()
                    {
                        Id = comment.Id,
                        PostId = comment.PostId,
                        PosNum = comment.PosNum,
                        Text = comment.Text,
                        User = user
                    });
                }

            return commentDTOs;
        }
    }
}
