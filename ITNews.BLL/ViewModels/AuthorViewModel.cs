using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.BLL.ViewModels
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }      
        public int Likes { get; set; }
        public virtual ICollection<NewsViewModel> News { get; set; }
        public virtual ICollection<CommentViewModel> Comments { get; set; }
    }
}
