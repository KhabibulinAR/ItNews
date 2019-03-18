using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITNews.BLL.Interfaces;
using ITNews.DAL.Interfaces;

namespace ITNews.BLL.Services
{
    public class TagService :ITagService
    {
        private IUnitOfWork database { get; set; }
        public TagService(IUnitOfWork database)
        {
            this.database = database;
        }

        //public string getTag(int id)
        //{
        //    var news = database.News.Get(id);
        //    var listtag = news.Tags.Select(s => s.TagName);
        //    var tagsString = string.Join(",", listtag);
        //    return tagsString;
        //}
    }
}
