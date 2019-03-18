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
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork database { get; set; }
        private IMapper mapper;
        public CategoryService(IUnitOfWork database)
        {
            this.database = database;
        }

        public IEnumerable<CategoryViewModel> GetAllCategory()
        {
            var categories = mapper.Map<IEnumerable<CategoryEntityModel>, IEnumerable<CategoryViewModel>>(database.Categories.GetAll());
            return categories;
        }
    }
}
