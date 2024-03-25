using CandyShop_API.ViewModel;
using System.Collections.Generic;
using System;

namespace CandyShop_API.Repositories
{
    public interface IImageRepository
    {
        List<ImageVM> GetAll();
        ImageVM GetByID(Guid id);
        ImageVM Add(ImageVM imageVM);
        ImageVM Update(ImageVM imageVM);
    }
}
