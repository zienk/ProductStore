using DataAccessLayer;
using DataAccessLayer.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories()
            => CategoryDAO.GetCategories();
    }
}
