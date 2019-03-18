using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ITNews.DAL.EntityModels;
using ITNews.DAL.Interfaces;
using ITNews.DAL.EF;

namespace ITNews.DAL.Repositories
{
    public class CategoryRepository : IRepository<CategoryEntityModel>
    {
        private NewsContext db;

        public CategoryRepository(NewsContext context)
        {
            this.db = context;
        }

        public void Create(CategoryEntityModel item)
        {
            db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            CategoryEntityModel category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }
        }

        public IEnumerable<CategoryEntityModel> Find(Func<CategoryEntityModel, bool> predicate)
        {
            return db.Categories.Where(predicate).ToList();
                 
        }

        public CategoryEntityModel Get(int id)
        {
            var category = db.Categories.FirstOrDefault(s => s.CategoryId == id);
            return category;
        }

        public IEnumerable<CategoryEntityModel> GetAll()
        {
            return db.Categories.ToList();
        }

        public void Update(CategoryEntityModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
