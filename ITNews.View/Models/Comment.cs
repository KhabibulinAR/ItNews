using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITNews.View.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int NewsId { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime CommentCreated { get; set; }
        public Author Author { get; set; }  
        public News News { get; set; }
    }
}