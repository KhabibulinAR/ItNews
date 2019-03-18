using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.BLL.ViewModels
{
    public class NewsViewModel
    {
        public int NewsId { get; set; }
        public int AuthorId { get; set; }
        public DateTime NewsCreated { get; set; }
        public string Title { get; set; }
        public AuthorViewModel Author { get; set; }
        public string Summary { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public int RatingCount { get; set; }
        public decimal Rating { get; set; }
        public int[] TagsId { get; set; }
        public virtual ICollection<TagViewModel> Tags { get; set; }
        public virtual ICollection<CommentViewModel> Comments { get; set; }
    }
}
