using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.DAL.EntityModels
{
    public class CommentEntityModel
    {
        [Key]
        public int CommentId { get; set; }
        public int? NewsId { get; set; }
        public int? AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime CommentCreated { get; set; }
        public AuthorEntityModel Author { get; set; }
        public NewsEntityModel News { get; set; }

    }
}
