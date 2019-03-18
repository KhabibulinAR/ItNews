using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.DAL.EntityModels
{
    public class TagEntityModel
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<NewsEntityModel> News { get; set; }
    }
}
