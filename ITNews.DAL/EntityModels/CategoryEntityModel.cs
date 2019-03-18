using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.DAL.EntityModels
{
    public class CategoryEntityModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<NewsEntityModel> News { get; set; }
    }
}
