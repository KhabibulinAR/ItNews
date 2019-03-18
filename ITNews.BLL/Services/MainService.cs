using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNews.DAL.Interfaces;
using ITNews.DAL.Repositories;
using ITNews.BLL.Interfaces;

namespace ITNews.BLL.Services
{
    public class MainService : IMainService
    {
        private IUnitOfWork database;
        private IAuthorService authorService;
        public IAuthorService AuthorService
        {
            get
            {
                if (authorService == null)
                    authorService = new AuthorService(database);
                return authorService;
            }
        }

        private ICategoryService categoryService;
        public ICategoryService CategoryService
        {
            get
            {
                if (categoryService == null)
                    categoryService = new CategoryService(database);
                return categoryService;
            }
        }

        private ICommentService commentService;
        public ICommentService CommentService
        {
            get
            {
                if (commentService == null)
                    commentService = new CommentService(database);
                return commentService;
            }
        }

        private INewsService newsService;
        public INewsService NewsService
        {
            get
            {
                if (newsService == null)
                    newsService = new NewsService(database);
                return newsService;
            }
        }

        private ITagService tagService;
        public ITagService TagService
        {
            get
            {
                if (tagService == null)
                    tagService = new TagService(database);
                return tagService;
            }
        }

        public MainService()
        {
            this.database = new EFUnitOfWork();
        }
    }
}
