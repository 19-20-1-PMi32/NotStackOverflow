using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class PostTagsRepository: Repository<PostTags>, IPostTagsRepository
    {
        public PostTagsRepository(ApplicationContext applicationContext): base(applicationContext) 
        {
        }
    }
}
