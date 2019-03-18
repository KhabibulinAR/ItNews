using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.BLL.Interfaces
{
    public interface IMainService
    {
        IAuthorService AuthorService { get; }
        ICategoryService CategoryService { get; }
        ICommentService CommentService { get; }
        INewsService NewsService { get; }
        ITagService TagService { get; }
    }
}
