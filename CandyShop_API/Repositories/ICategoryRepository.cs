using System.Linq.Expressions;
using System.Linq;
using System;
using CandyShop_API.Model;
using System.Collections.Generic;

namespace CandyShop_API.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetByID(int id);
        CategoryVM GetByName(string name);
        CategoryVM Add(string name);
        CategoryVM Update(CategoryVM category);
    }
}
