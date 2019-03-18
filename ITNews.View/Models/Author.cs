using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITNews.View.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Likes { get; set; }       
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}