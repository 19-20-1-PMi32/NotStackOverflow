using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DTOEntities;
using DAL.Entities;

namespace BLL.Mapping
{
    public static class TagMapper
    {
        public static ICollection<TagDTO> ToListTagDTO(this ICollection<Tag> tags)
        {
            if (tags == null)
            {
                return new List<TagDTO>();
            }
            return tags.Select(tag => new TagDTO() 
                    {
                        Id = tag.Id, 
                        Description = tag.Description,
                        Title = tag.Title
                    })
                .ToList();
        }
    }
}
