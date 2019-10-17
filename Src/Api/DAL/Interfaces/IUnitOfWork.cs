using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAchievementsRepository Achievements { get; set; }

        ICommentRepository Comments { get; set; }

        IPostRepository Posts { get; set; }

        IPostTagsRepository PostTags { get; }

        ITagRepository Tags { get; }

        IUserAchievementsRepository UserAchievements { get; }

        IUserRepository Users { get; }

        IAuthorizedUsersRepository AuthorizedUsers { get; }

        void Save();
    }
}
