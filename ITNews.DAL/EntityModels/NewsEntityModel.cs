using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITNews.DAL.EntityModels
{
    public class NewsEntityModel
    {
        [Key]
        public int NewsId { get; set; }
        public int? AuthorId { get; set; }
        public AuthorEntityModel Author { get; set; }
        public DateTime NewsCreated { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public int RatingCount { get; set; }
        public decimal Rating { get; set; }
        public int[] TagsId { get; set; }
        public virtual ICollection<TagEntityModel> Tags { get; set; }
        public virtual ICollection<CommentEntityModel> Comments { get; set; }

        public NewsEntityModel()
        {
            this.Comments = new HashSet<CommentEntityModel>();
        }
    }
}


