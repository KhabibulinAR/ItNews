using AutoMapper;
using HeyRed.MarkdownSharp;
using ITNews.BLL.Services;
using ITNews.BLL.ViewModels;
using ITNews.View.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITNews.View.Controllers
{
    public class CommentController : Controller
    {

        IMapper mapper;
        private MainService MainService;

        public CommentController()
        {
            MainService = new MainService();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentViewModel>();
                 
                cfg.CreateMap<CommentViewModel, Comment>();


            }).CreateMapper();
        }
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }


        private Author GetAuthor(string username)
        {
            var authorview = MainService.AuthorService.GetAuthorByName(username);
            Author author = mapper.Map<AuthorViewModel, Author>(authorview);
            return author;
        }
        [Authorize(Roles = "Administrator, writer")]
        public ActionResult Delete (int commentId, int newsId)
        {
            MainService.CommentService.Delete(commentId);
            return RedirectToAction("Details", "News", new { id = newsId });
        }
      
        [HttpGet]
        [Authorize(Roles = "Administrator, writer, reader")]
        public PartialViewResult Create(int NewsId)
        {
            var Author = GetAuthor(User.Identity.GetUserName());
            return PartialView(new Comment { NewsId = NewsId, AuthorId = Author.AuthorId });
        }


        [HttpPost]
        [Authorize(Roles = "Administrator, writer, reader")]
        public ActionResult Create(Comment comment)
        {

            MainService.CommentService.CreateComment(mapper.Map<Comment, CommentViewModel>(comment));
            return RedirectToAction("Details", "News", new { id = comment.NewsId });
        }
    }
}