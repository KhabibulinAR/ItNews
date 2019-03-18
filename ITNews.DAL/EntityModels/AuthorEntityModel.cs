using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.DAL.EntityModels
{
    public class AuthorEntityModel
    {
        [Key]
        public int AuthorId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Likes { get; set; }
        public virtual ICollection<NewsEntityModel> News { get; set; }
        public virtual ICollection<CommentEntityModel> Comments { get; set; }

        public AuthorEntityModel()
        {
            this.News = new HashSet<NewsEntityModel>();
            this.Comments = new HashSet<CommentEntityModel>();
        }
    }
}
