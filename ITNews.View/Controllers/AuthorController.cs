using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITNews.BLL.ViewModels;
using ITNews.BLL.Services;
using ITNews.View.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;

namespace ITNews.View.Controllers
{
    public class AuthorController : Controller
    {
        IMapper mapper;
        private MainService MainService;
        public AuthorController()
        {
            MainService = new MainService();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorViewModel>();

                cfg.CreateMap<AuthorViewModel, Author>();


            }).CreateMapper();
        }


        private Author GetAuthor(string Username)
        {
            var authorview = MainService.AuthorService.GetAuthorByName(Username);
            Author author = mapper.Map<AuthorViewModel, Author>(authorview);
            return author;

        }
        // GET: Author
        public ActionResult Index()
        {                        
            return View();
        }

        [Authorize(Roles = "Administrator, writer, reader")]
        public ActionResult Like (int authorId,int newsId)
        {
            var Author = MainService.AuthorService.GetAuthorById(authorId);
            Author.Likes++;
            MainService.AuthorService.Update(Author);
            return RedirectToAction("Details","News", new {id = newsId }); 
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, writer, reader")]
        public ActionResult Edit(string pk, string name, string value)
        {
            var author = MainService.AuthorService.GetAuthorById(Convert.ToInt32(pk));
            Author Author = mapper.Map<AuthorViewModel, Author>(author);

            switch (name)
            {
                case "firstname":
                    Author.Firstname = value;
                    break;
                case "lastname":
                    author.Lastname = value;
                    break;

            }
            MainService.AuthorService.Update(mapper.Map<Author, AuthorViewModel>(Author));

            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }

        public ActionResult Details (string Username)
        {
            var Author = GetAuthor(Username);         
            return View(Author);
        }


    }
}