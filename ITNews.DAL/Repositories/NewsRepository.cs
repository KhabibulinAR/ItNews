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
    class NewsRepository : IRepository<NewsEntityModel>
    {
        private NewsContext db;

        public NewsRepository(NewsContext context)
        {
            this.db = context;
        }

        public void Create(NewsEntityModel item)
        {
            db.News.Add(item);
        }

        public void Delete(int id)
        {
            NewsEntityModel news = db.News.Find(id);
            if (news != null)
            {
                db.News.Remove(news);
            }
        }

        public IEnumerable<NewsEntityModel> Find(Func<NewsEntityModel, bool> predicate)
        {
            return db.News.Include(a => a.Author).Include(t=>t.Tags).Include(c=>c.Comments).Where(predicate).ToList();
         //   return db.News.Where(predicate).ToList();
        }

        public NewsEntityModel Get(int id)
        {
            var news = db.News.Include(a => a.Author).Include(t=>t.Tags).Include(c => c.Comments).FirstOrDefault(s => s.NewsId == id);
            // var news = db.News.FirstOrDefault(s => s.NewsId == id);
           // var listtag = news.Tags.Select(s => s.TagName);
           // var tagsString = string.Join(",", listtag);
            return news;
        }

        //public string getTag(int Id)
        //{
        //    var news = db.News.Include(a => a.Author).Include(t => t.Tags).FirstOrDefault(s => s.NewsId == Id);
        //    var listtag = news.Tags.Select(s => s.TagName);
        //    var tagsString = string.Join(",", listtag);
        //    return tagsString;
        //}

        public IEnumerable<NewsEntityModel> GetAll()
        {
            return db.News.Include(a => a.Author).Include(t=>t.Tags).Include(c => c.Comments).ToList();
          //  return db.News.ToList();
        }

        public void Update(NewsEntityModel item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
