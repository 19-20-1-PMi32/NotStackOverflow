using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DTOEntities;
using DAL.Entities;

namespace BLL.Mapping
{
    public static class PostMapper
    {
        public static PostDTO ToPostDTO(this Post post)
        {
            return new PostDTO()
            {
                Id = post.Id,
                PostId = post.PostId,
                PostNum = post.PostNum,
                UpVotes = post.UpVotes,
                DownVotes = post.DownVotes,
                Text = post.Text,
                Title = post.Title,
                Viewed = post.Viewed,
                DateOfPublish = post.DateOfPublish,
                Comments = post.Comments.ToCommentDTOs(),
                PostTags = post.PostTags
                    .Select(p => p.Tag)
                    .Where(p => p != null)
                    .ToList()
                    .ToListTagDTO(),
                User = post.User.ToPreviewUserDTO()
            };
        }

        public static Post ToPost(this CreatePostDTO postDTO)
        {
            return new Post()
            {
                PostId = postDTO.PostId,
                PostNum = postDTO.PostNum,
                UpVotes = postDTO.UpVotes,
                DownVotes = postDTO.DownVotes,
                Text = postDTO.Text,
                Title = postDTO.Title,
                Viewed = postDTO.Viewed,
                DateOfPublish = postDTO.DateOfPublish,
                UserId = postDTO.UserId
            };
        }

        public static PreviewPostDTO ToPreviewPostDTO(this Post post)
        {
            return new PreviewPostDTO()
            {
                Id = post.Id,
                Title = post.Title,
                Text = post.Text,
                UpVotes = post.UpVotes,
                DownVotes = post.DownVotes,
                Viewed = post.Viewed,
                PreviewUserDTO = post.User.ToPreviewUserDTO()
            };
        }
    }
}
