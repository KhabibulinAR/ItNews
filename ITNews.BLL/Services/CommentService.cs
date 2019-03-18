using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ITNews.BLL.Interfaces;
using ITNews.BLL.ViewModels;
using ITNews.DAL.EntityModels;
using ITNews.DAL.Interfaces;

namespace ITNews.BLL.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork database { get; set; }
        private IMapper mapper;
        
        public CommentService(IUnitOfWork database)
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentEntityModel, CommentViewModel>();
                cfg.CreateMap<CommentViewModel, CommentEntityModel>();
            }).CreateMapper();
            this.database = database;
        }

        public void Delete (int commentId)
        {
            database.Comments.Delete(commentId);
            database.Save();
        }

        public void CreateComment(CommentViewModel item)
        {
            item.CommentCreated = DateTime.Now;
            database.Comments.Create(mapper.Map<CommentViewModel, CommentEntityModel>(item));
            database.Save();
        }
    }
}
