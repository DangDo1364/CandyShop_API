using CandyShop_API.Data;
using CandyShop_API.Model;
using CandyShop_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Image = CandyShop_API.Model.Image;

namespace CandyShop_API.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly MyDBContext _myDBContext;

        public ImageRepository(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public ImageVM Add(ImageVM imageVM)
        {
            var image = new Image
            {
                idImg = Guid.NewGuid(),
                idPro = imageVM.idPro,
                path = imageVM.path,
            };

            _myDBContext.Images.Add(image);
            _myDBContext.SaveChanges();

            return new ImageVM {
                idImg = image.idImg,
                idPro = image.idPro,
                path = image.path,
            };
        }

        public List<ImageVM> GetAll()
        {
            var list = _myDBContext.Images.Select(image => new ImageVM
            {
                idImg = image.idImg,
                idPro = image.idPro,
                path = image.path,

            }).ToList();

            return list;
        }

        public ImageVM GetByID(Guid id)
        {
            var image = _myDBContext.Images.FirstOrDefault(c => c.idImg == id);

            if (image == null)
                return null;
            else
                return new ImageVM
                {
                    idImg = image.idImg,
                    idPro = image.idPro,
                    path = image.path,
                };    
        }

        public ImageVM Update(ImageVM imageVM)
        {
            var image = _myDBContext.Images.FirstOrDefault(c => c.idImg == imageVM.idImg);

            if (image == null)
                return null;

            image.path = imageVM.path;

            _myDBContext.Update(image);
            _myDBContext.SaveChanges();

            return new ImageVM
            {
                idImg = image.idImg,
                idPro = image.idPro,
                path = image.path,
            };
        }
    }
}
