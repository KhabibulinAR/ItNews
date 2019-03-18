using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNews.DAL.EntityModels;

namespace ITNews.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<NewsEntityModel> News { get; }
        IRepository<AuthorEntityModel> Authors { get; }
        IRepository<CategoryEntityModel> Categories { get; }
        IRepository<CommentEntityModel> Comments { get; }
        IRepository<TagEntityModel> Tags { get; }
        void Save();
    }
}
