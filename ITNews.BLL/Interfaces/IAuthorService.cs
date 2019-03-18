using ITNews.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.BLL.Interfaces
{
    public interface IAuthorService
    {
        AuthorViewModel GetAuthorByName(string username);
        AuthorViewModel GetAuthorById(int authorId);
        void CreateAuthor(AuthorViewModel item);
        void Update(AuthorViewModel item);
    }
}
