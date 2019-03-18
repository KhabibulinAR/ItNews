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
    class CommentRepository : IRepository<CommentEntityModel>
    {
        private NewsContext db;

        public CommentRepository(NewsContext context)
        {
            this.db = context;
        }

        public void Create(CommentEntityModel item)
        {
            db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            CommentEntityModel comment = db.Comments.Find(id);
            if (comment != null)
            {
                db.Comments.Remove(comment);
            }
        }

        public IEnumerable<CommentEntityModel> Find(Func<CommentEntityModel, bool> predicate)
        {
            return db.Comments.Include(a=>a.Author).Where(predicate).ToList();
        }

        public CommentEntityModel Get(int id)
        {
            var comment = db.Comments.Include(a => a.Author).FirstOrDefault(s => s.CommentId == id);
            return comment;
        }

        public IEnumerable<CommentEntityModel> GetAll()
        {
            return db.Comments.Include(a => a.Author).ToList();
        }

        public void Update(CommentEntityModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
