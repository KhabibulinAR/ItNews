using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.BLL.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int NewsId { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime CommentCreated { get; set; }
        public AuthorViewModel Author { get; set; }
        public NewsViewModel News { get; set; }
    }
}
