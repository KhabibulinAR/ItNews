using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITNews.View.Models;
using AutoMapper;
using ITNews.BLL.Services;
using ITNews.BLL.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HeyRed.MarkdownSharp;

namespace ITNews.View.Controllers
{
    public class NewsController : Controller
    {
        IMapper mapper;
        private MainService MainService;
        

        public NewsController()
        {
            MainService = new MainService();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsViewModel>()
                 .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.FirstOrDefault()));               
                cfg.CreateMap<NewsViewModel, News>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Split()));
                               
            }).CreateMapper();
        }
        [Authorize]
        private Author GetAuthor(string username)
        {
            var authorview = MainService.AuthorService.GetAuthorByName(username);
            Author author = mapper.Map<AuthorViewModel, Author>(authorview);
            return author;
        }

       // [Authorize]
        public ActionResult Index(string sort)
        {
            ViewBag.DateSortParam = String.IsNullOrEmpty(sort) ? "Date" : "";
            ViewBag.AuthorSortParam = sort =="Author" ? "author_desc" : "Author";

            IEnumerable<News> ListNews;
            ListNews = mapper.Map<IEnumerable<NewsViewModel>, IEnumerable<News>>(MainService.NewsService.GetAllNews());


            switch (sort)
            {                                  
                case "author_desc":
                    ListNews = ListNews.OrderByDescending(s => s.Author.Username);
                    break;
                case "Author":
                    ListNews = ListNews.OrderBy(s => s.Author.Username);
                    break;
                case "Date":
                    ListNews = ListNews.OrderBy(s => s.NewsCreated);
                    break;
                default:
                    ListNews = ListNews.OrderByDescending(s => s.NewsCreated);
                    break;
            }

            return View(ListNews);
        }
        [Authorize(Roles = "Administrator, writer")]
        public ActionResult Create()
        {
            var Author = GetAuthor(User.Identity.GetUserName());
            return View( new News {AuthorId = Author.AuthorId } );
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, writer")]
        public ActionResult Create(News news)
        {
            var Author = GetAuthor(User.Identity.GetUserName());
            MainService.NewsService.CreateNews(mapper.Map<News, NewsViewModel>(news));
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrator, writer, reader")]
        public PartialViewResult AddRating (int NewsId)
        {
            return PartialView(new News { NewsId = NewsId});
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator, writer, reader")]
        public ActionResult AddRating (News news)
        {           
            MainService.NewsService.AddRating(mapper.Map<News, NewsViewModel>(news));
            return RedirectToAction("Details", "News", new { id = news.NewsId });
        }
        
     
        public ActionResult Details (int id)
        {
            News item = mapper.Map<NewsViewModel, News>(MainService.NewsService.GetNewsById(id));
            string html = item.Content;
            var rating = item.Rating;
            var ratinCount = item.RatingCount;
            decimal totalRating;
            if (ratinCount == 0)
            {
                totalRating = 0.0M;
            }
            else
            {
                totalRating = rating / ratinCount;
            }
            if (totalRating % 1 >= 0.5M)
            {
                ViewBag.totalRating = Convert.ToInt32(Math.Round(totalRating));
            }
            else
            {
                ViewBag.totalRating = Convert.ToInt32(Math.Floor(totalRating));
            }

            ViewBag.AvgRating = Math.Round(totalRating,3);
            ViewBag.RatingCount = ratinCount;

            var options = new MarkdownOptions
            {
                AutoHyperlink = true,
                AutoNewLines = true,
                LinkEmails = true,
                QuoteSingleLine = true,
                StrictBoldItalic = true
            };

            Markdown markdown = new Markdown(options);
            var a = markdown.Transform(html);
            item.Content = a;            
            return View(item);
        }

        [Authorize(Roles = "Administrator, writer")]
        public ActionResult Edit (int id)
        {
            News item = mapper.Map<NewsViewModel, News>(MainService.NewsService.GetNewsById(id));
            return View(item);
        }


        [HttpPost]
        [Authorize(Roles = "Administrator, writer")]
        public ActionResult Edit(News News)
        {
            MainService.NewsService.Update(mapper.Map<News, NewsViewModel>(News));            
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator, writer")]
        public ActionResult Delete(int id)
        {
            MainService.NewsService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}