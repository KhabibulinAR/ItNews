using ITNews.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.BLL.Interfaces
{
    public interface INewsService
    {
        IEnumerable<NewsViewModel> GetAllNews();
        NewsViewModel GetNewsById(int id);
        void CreateNews(NewsViewModel news);
        IEnumerable<NewsViewModel> GetNewsByName(string name);
        void AddRating(NewsViewModel news);
        void Delete(int id);
        void Update(NewsViewModel item);
    }
}
