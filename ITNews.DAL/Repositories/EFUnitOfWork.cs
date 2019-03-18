using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNews.DAL.Interfaces;
using ITNews.DAL.EntityModels;
using ITNews.DAL.EF;

namespace ITNews.DAL.Repositories
{
    public class EFUnitOfWork  : IUnitOfWork
    {
        private NewsContext db;

        public EFUnitOfWork()
        {
            db = new NewsContext();
        }

        private IRepository<NewsEntityModel> newsRepository;
        public IRepository<NewsEntityModel> News
        {
            get
            {
                if (newsRepository == null)
                    newsRepository = new NewsRepository(db);
                return newsRepository;              
            }
        }

        private IRepository<AuthorEntityModel> authorRepository;
        public IRepository<AuthorEntityModel> Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new AuthorRepository(db);
                return authorRepository;
            }
        }

        private IRepository<CategoryEntityModel> categoryRepository;
        public IRepository<CategoryEntityModel> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        private IRepository<CommentEntityModel> commentRepository;
        public IRepository<CommentEntityModel> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        private IRepository<TagEntityModel> tagRepository;
        public IRepository<TagEntityModel> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(db);
                return tagRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
