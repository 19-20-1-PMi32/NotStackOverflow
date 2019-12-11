using AutoMapper;
using BLL.DTOEntities;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Service
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public TagService(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TagDTO, Tag>().ReverseMap();
            }).CreateMapper();
        }
        public void Create(TagDTO tagDto)
        {
            var tag = _mapper.Map<TagDTO, Tag>(tagDto);
             _database.Tags.Add(tag);
             _database.Save();
            
        }

        public void Remove(int id)
        {
            var tag = _database.Tags.GetById(id);
            
            _database.Tags.Remove(tag);
            _database.Save();
        }
    }
}