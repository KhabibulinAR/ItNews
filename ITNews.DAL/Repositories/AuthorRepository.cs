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
    public class AuthorRepository : IRepository<AuthorEntityModel>
    {
        private NewsContext db;

        public AuthorRepository(NewsContext context)
        {
            this.db = context;
        }

        public void Create(AuthorEntityModel item)
        {
            db.Authors.Add(item);
        }

        public void Delete(int id)
        {
            AuthorEntityModel author = db.Authors.Find(id);
            if (author != null)
            {
                db.Authors.Remove(author);
            }
        }

        public IEnumerable<AuthorEntityModel> Find(Func<AuthorEntityModel, bool> predicate)
        {
            return db.Authors.Include(c => c.Comments).Include(n=>n.News).Where(predicate).ToList();
        }

        

        public AuthorEntityModel Get(int id)
        {
            var author = db.Authors.Include(c => c.Comments).Include(n => n.News).FirstOrDefault(s => s.AuthorId == id);
            return author;
        }

        public IEnumerable<AuthorEntityModel> GetAll()
        {
            return db.Authors.Include(c=>c.Comments).ToList();
        }

        public void Update(AuthorEntityModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
