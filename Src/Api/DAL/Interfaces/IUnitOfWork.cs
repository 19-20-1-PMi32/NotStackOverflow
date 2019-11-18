using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAchievementsRepository Achievements { get; }

        ICommentRepository Comments { get; }

        IPostRepository Posts { get; }

        IPostTagsRepository PostTags { get; }

        ITagRepository Tags { get; }

        IUserAchievementsRepository UserAchievements { get; }

        IUserRepository Users { get; }

        IAuthorizedUsersRepository AuthorizedUsers { get; }

        ILikeRepository Likes { get; }

        void Save();
    }
}
