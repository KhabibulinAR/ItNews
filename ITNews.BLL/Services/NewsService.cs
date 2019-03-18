using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNews.BLL.Interfaces;
using AutoMapper;
using ITNews.DAL.EntityModels;
using ITNews.BLL.ViewModels;
using ITNews.DAL.Interfaces;

namespace ITNews.BLL.Services
{
    public class NewsService : INewsService
    {
        private IUnitOfWork database { get; set; }
        private IMapper mapper;
        public NewsService(IUnitOfWork database)
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsEntityModel, NewsViewModel>();
                // .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));
                // .ForMember(dest => dest.Category)

                cfg.CreateMap<NewsViewModel, NewsEntityModel>();
               // .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));
             
            }).CreateMapper();
            this.database = database;
        }
        public IEnumerable<NewsViewModel> GetAllNews()
        {         
            var news = mapper.Map<IEnumerable<NewsEntityModel>, IEnumerable<NewsViewModel>>(database.News.GetAll());

            return news;
        }
        public NewsViewModel GetNewsById(int id)
        {
            var news = mapper.Map<NewsEntityModel, NewsViewModel>(database.News.Get(id));          
            return news;
        }

        public IEnumerable<NewsViewModel> GetNewsByName(string search)
        {

            var news = mapper.Map<IEnumerable<NewsEntityModel>, IEnumerable<NewsViewModel>>(database.News.Find(x => x.Title.Contains(search) 
                                                                                                                 || x.Summary.Contains(search)).ToList());
            return news;
        }
        
        public void AddRating(NewsViewModel news)
        {            
            NewsEntityModel newsEntity = mapper.Map<NewsViewModel, NewsEntityModel>(news);
            NewsEntityModel News = database.News.Get(newsEntity.NewsId);
            News.RatingCount++;
            News.Rating += newsEntity.Rating;
            database.News.Update(News);
            database.Save();
        }

        public void Update(NewsViewModel item)
        {
            NewsEntityModel news = mapper.Map<NewsViewModel, NewsEntityModel>(item);
            NewsEntityModel News = database.News.Get(news.NewsId);
            News.Summary = news.Summary;
            News.Title = news.Title;
            News.Content = news.Content;
            News.Category = news.Category;
            database.News.Update(News);
            database.Save();
        }

        public void Delete (int id)
        {
            database.News.Delete(id);
            database.Save();
        }

        public void CreateNews(NewsViewModel news)
        {         
            news.NewsCreated = DateTime.Now;

            NewsEntityModel newsEntity = new NewsEntityModel();
           
            newsEntity = mapper.Map<NewsViewModel, NewsEntityModel>(news);
            database.News.Create(newsEntity);
            database.Save();           
        }
    }
}
