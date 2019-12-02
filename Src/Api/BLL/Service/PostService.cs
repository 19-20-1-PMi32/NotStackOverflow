using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BLL.DTOEntities;
using BLL.Interfaces;
using BLL.Mapping;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace BLL.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork database)
        {
            _database = database;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentDTO, Comment>().ReverseMap();
                cfg.CreateMap<PostDTO, Post>()
                    .ForMember(p => p.PostTags, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(p => p.Tags, opt => opt.Ignore())
                    .ForMember(p => p.PostTags, opt => opt.Ignore());
                cfg.CreateMap<TagDTO, Tag>().ReverseMap();
            }).CreateMapper();
        }

        public PostDTO CreatePost(CreatePostDTO postDTO)
        {
            var post = postDTO.ToPost();

            if (EnumerableExtensions.Any(postDTO.Tags))
                foreach (var tagId in postDTO.Tags)
                {
                    var postTags = new PostTags() {Post = post, TagId = tagId};
                    post.PostTags.Add(postTags);
                }

            if (postDTO.PostId != 0)
            {
                ++post.PostNum;
                _database.Posts.Add(post);
                
            }
            else
            {
                _database.Posts.Add(post);
                _database.Save();
                post.PostId = post.Id;
                _database.Posts.Update(post);
            }

            _database.Save();
            return post.ToPostDTO();
        }

        #region UpdateRegion

        public int UpdateDownVotes(int id)
        {
            var post = _database.Posts.GetById(id);

            ++post.DownVotes;
            _database.Posts.Update(post);
            _database.Save();

            return post.DownVotes;
        }

        public int UpdateUpVotes(int id)
        {
            var post = _database.Posts.GetById(id);

            ++post.UpVotes;
            _database.Posts.Update(post);
            _database.Save();

            return post.UpVotes;
        }

        public string UpdateText(int id, string text)
        {
            var post = _database.Posts.GetById(id);

            post.Text = text;
            _database.Posts.Update(post);
            _database.Save();

            return post.Text;
        }

        public int UpdateViews(int id)
        {
            var post = _database.Posts.GetById(id);

            ++post.Viewed;
            _database.Posts.Update(post);
            _database.Save();

            return post.Viewed;
        }


        #endregion

        public void RemovePost(int id)
        {
            var post = _database.Posts.GetById(id);

            _database.Posts.Remove(post);
            _database.Save();
        }

        public PostDTO GetPostById(int id)
        {
            return _database.Posts.GetById(id).ToPostDTO();
        }

        public IEnumerable<PostDTO> GetPostsWithComments(int postId, int page)
        {
            //return _mapper.Map<IEnumerable<Post>, ICollection<PostDTO>>(_database.Posts.GetPostsWithComments(postId, startFrom, amount));
            return _database.Posts.GetPostsWithComments(postId, page).Select(p => p.ToPostDTO());
        }

        public IEnumerable<PreviewPostDTO> GetPostList(int amount)
        {
            //return _mapper.Map<IEnumerable<Post>, ICollection<PostDTO>>(_database.Posts.GetPostList(startFrom, amount));
            return _database.Posts.GetPostList(amount).Select(p => p.ToPreviewPostDTO());
        }

        public IEnumerable<PreviewPostDTO> GetUsersPostById(int userId)
        {
            return _database.Posts.GetUsersPostsById(userId)
                .Select(p => p.ToPreviewPostDTO()).ToList();
        }

        public int SetLike(VoteDTO voteDto)
        {
            var post = _database.Posts.GetById(voteDto.PostId);
            var like = _database.Votes.GetById(voteDto.PostId, voteDto.UserId);
            if (like == null)
            {
                ++post.UpVotes;

                _database.Votes.Add(new Vote
                {
                    PostId = voteDto.PostId,
                    UserId = voteDto.UserId,
                    IsLiked = true
                });
            }
            else if(!like.IsLiked)
            {
                ++post.UpVotes;
                --post.DownVotes;
                like.IsLiked = true;
            }
            else
            {
                --post.UpVotes;
                _database.Votes.Remove(like);
            }

            _database.Save();

            return post.UpVotes;
        }

        public int SetDislike(VoteDTO voteDto)
        {
            var post = _database.Posts.GetById(voteDto.PostId);
            var dislike = _database.Votes.GetById(voteDto.PostId, voteDto.UserId);
            if (dislike == null)
            {
                ++post.DownVotes;
                _database.Votes.Add(new Vote
                {
                    PostId = voteDto.PostId,
                    UserId = voteDto.UserId,
                    IsLiked = true
                });
            }
            else if (dislike.IsLiked)
            {
                --post.UpVotes;
                ++post.DownVotes;
                dislike.IsLiked = false;
            }
            else
            {
                --post.UpVotes;
                _database.Votes.Remove(dislike);
            }
            _database.Save();

            return post.DownVotes;
        }

    }
}
