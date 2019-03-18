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
    class TagRepository : IRepository<TagEntityModel>
    {
        private NewsContext db;

        public TagRepository(NewsContext context)
        {
            this.db = context;
        }

        public void Create(TagEntityModel item)
        {
            db.Tags.Add(item);
        }

        public void Delete(int id)
        {
            TagEntityModel tag = db.Tags.Find(id);
            if (tag != null)
            {
                db.Tags.Remove(tag);
            }
        }

        public IEnumerable<TagEntityModel> Find(Func<TagEntityModel, bool> predicate)
        {
            return db.Tags.Where(predicate).ToList();
        }

        public TagEntityModel Get(int id)
        {
            var tag = db.Tags.FirstOrDefault(s => s.TagId == id);
            return tag;
        }

        public IEnumerable<TagEntityModel> GetAll()
        {
            return db.Tags.ToList();
        }

        public void Update(TagEntityModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
