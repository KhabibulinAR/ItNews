using ITNews.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNews.BLL.Interfaces;
using AutoMapper;
using ITNews.DAL.EntityModels;
using ITNews.BLL.ViewModels;

namespace ITNews.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork database { get; set; }
        private IMapper mapper;
        public AuthorService(IUnitOfWork database)
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorEntityModel, AuthorViewModel>();
                cfg.CreateMap<AuthorViewModel, AuthorEntityModel>();
            }).CreateMapper();
            this.database = database;
        }

        public AuthorViewModel GetAuthorByName(string username)
        {
            var author = mapper.Map<AuthorEntityModel, AuthorViewModel>(database.Authors.Find(s => s.Username == username).FirstOrDefault());
            return author;
        }

        public AuthorViewModel GetAuthorById(int authorId)
        {
            var author = mapper.Map<AuthorEntityModel, AuthorViewModel>(database.Authors.Get(authorId));
            return author;
        }

        public void CreateAuthor (AuthorViewModel item)
        {
           
            database.Authors.Create(mapper.Map<AuthorViewModel,AuthorEntityModel>(item));
            database.Save();
        }

        public void Update(AuthorViewModel item)
        {
            AuthorEntityModel author = mapper.Map<AuthorViewModel, AuthorEntityModel>(item);
            AuthorEntityModel Author = database.Authors.Get(author.AuthorId);
            Author.Likes = author.Likes;
            Author.Firstname = author.Firstname;
            Author.Lastname = author.Lastname;
            database.Authors.Update(Author);
            database.Save();
        }

    }
}
