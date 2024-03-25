using System.Linq.Expressions;
using System.Linq;
using System;
using System.Collections.Generic;
using CandyShop_API.ViewModel;

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
