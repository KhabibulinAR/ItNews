using ITNews.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITNews.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAllCategory();
    }
}
