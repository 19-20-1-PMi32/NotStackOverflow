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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork database)
        {
            _database = database;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDTO>().ReverseMap();
            }).CreateMapper();

        }
        
        public CommentDTO CreateComment(CommentDTO commentDTO)
        {
            var comment = _mapper.Map<CommentDTO, Comment>(commentDTO);
            _database.Comments.Add(comment);
            _database.Save();

            return _mapper.Map<Comment, CommentDTO>(comment);
        }

        public string UpdateComment(int id, string text)
        {
            var comment = _database.Comments.GetById(id);
            
            comment.Text = text;
            
            _database.Comments.Update(comment);
            _database.Save();
            
            return text;
        }

        public void RemoveComment(int id)// метод для адміна
        {
            var comment = _database.Comments.GetById(id);

            _database.Comments.Remove(comment);
            _database.Save();
        }

        public void RemoveComment(int id, int userId)
        {
            var comment = _database.Comments.GetById(id);

            if (comment.UserId != userId) return; //тарас кинь ексепшн 
            _database.Comments.Remove(comment);
            _database.Save();
        }
    }
}
