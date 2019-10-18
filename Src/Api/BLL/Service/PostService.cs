using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTOEntities;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

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
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<PostDTO, Post>();
            }).CreateMapper();
        }

        public PostDTO CreatePost(PostDTO postDTO)
        {
            var post = _mapper.Map<PostDTO, Post>(postDTO);

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
            return _mapper.Map<Post, PostDTO>(post);
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
            return _mapper.Map<Post, PostDTO>(_database.Posts.GetById(id));
        }

        public IEnumerable<PostDTO> GetPostsWithComments(int postId, int startFrom, int amount)
        {
            return _mapper.Map<IEnumerable<Post>, ICollection<PostDTO>>(_database.Posts.GetPostsWithComments(postId, startFrom, amount));
        }

        public IEnumerable<PostDTO> GetPostList(int startFrom, int amount)
        {
            return _mapper.Map<IEnumerable<Post>, ICollection<PostDTO>>(_database.Posts.GetPostList(startFrom, amount));
        }
    }
}
