using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITNews.View.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public int AuthorId { get; set; }
        public DateTime NewsCreated { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public IList<string> Category { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public int RatingCount { get; set; }
        public decimal Rating { get; set; }
        public int[] TagsId { get; set; }
        public virtual ICollection <Tag> Tags { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
            
}