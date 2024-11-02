using BusinessObject.Models;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool AddCategory(Category category) => CategoryDAO.Instance.AddCategory(category);


        public bool DeleteCategory(int id) => CategoryDAO.Instance.DeleteCategory(id);


        public Category GetCategory(int id) => CategoryDAO.Instance.GetCategory(id);

        public List<Category> GetAllCategories() => CategoryDAO.Instance.GetAllCategories();


        public bool UpdateProduct(Category category) => CategoryDAO.Instance.UpdateProduct(category);
    }
}
