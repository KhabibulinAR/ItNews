using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.BLL.ViewModels
{
    public class TagViewModel
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<NewsViewModel> News { get; set; }
    }
}
