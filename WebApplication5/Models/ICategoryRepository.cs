using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetCategoryById(int id);
        Category AddCategory(Category category);
        void DeleteCategory(int id);
        void UpdateCategory(Category category);
    }
}
