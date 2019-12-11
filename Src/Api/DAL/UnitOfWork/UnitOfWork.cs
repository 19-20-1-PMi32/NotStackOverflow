using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;

        public IAchievementsRepository Achievements { get; }

        public ICommentRepository Comments { get; }

        public IPostRepository Posts { get; }

        public IPostTagsRepository PostTags { get; }

        public ITagRepository Tags { get; }

        public IUserAchievementsRepository UserAchievements { get; }

        public IUserRepository Users { get; }

        public IAuthorizedUsersRepository AuthorizedUsers { get; }

        public IVoteRepository Votes { get; }

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _dbContext = applicationContext;
            Achievements = new AchievementRepository(applicationContext);
            Comments = new CommentRepository(applicationContext);
            Posts = new PostRepository(applicationContext);
            PostTags = new PostTagsRepository(applicationContext);
            Tags = new TagRepository(applicationContext);
            UserAchievements = new UserAchievementsRepository(applicationContext);
            Users = new UserRepository(applicationContext);
            AuthorizedUsers = new AuthorizedUsersRepository(applicationContext);
            Votes = new VoteRepository(applicationContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
