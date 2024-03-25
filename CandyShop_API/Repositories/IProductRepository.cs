using CandyShop_API.ViewModel;
using System;
using System.Collections.Generic;

namespace CandyShop_API.Repositories
{
    public interface IProductRepository
    {
        List<ProductVM> GetAll();
        ProductVM GetByID(Guid id);
        ProductVM GetByName(string name);
        ProductVM Add(ProductVM productVM);
        ProductVM Update(ProductVM productVM);
    }
}
