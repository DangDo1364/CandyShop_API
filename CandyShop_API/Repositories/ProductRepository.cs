using CandyShop_API.Data;
using CandyShop_API.Model;
using CandyShop_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CandyShop_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDBContext _myDBContext;

        public ProductRepository(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public ProductVM Add(ProductVM productVM)
        {
            var product = new Product
            {
                idPro = Guid.NewGuid(),
                name = productVM.name,
                idCate = productVM.idCate,
                price = productVM.price,
                discount = productVM.discount,
                description = productVM.description,
            };

            _myDBContext.Products.Add(product);
            _myDBContext.SaveChanges();

            return new ProductVM
            {
                idPro = product.idPro,
                name = product.name,
                idCate = product.idCate,
                price = product.price,
                discount = product.discount,
                description = product.description,
            };
        }

        public List<ProductVM> GetAll()
        {
            var list = _myDBContext.Products.Select(product => new ProductVM
            {
                idPro = product.idPro,
                name = product.name,
                idCate = product.idCate,
                price = product.price,
                discount = product.discount,
                description = product.description,

            }).ToList();

            return list;
        }

        public ProductVM GetByID(Guid id)
        {
            var product = _myDBContext.Products.FirstOrDefault(c => c.idPro == id);

            if (product == null)
                return null;
            else
                return new ProductVM
                {
                    idPro = product.idPro,
                    name = product.name,
                    idCate = product.idCate,
                    price = product.price,
                    discount = product.discount,
                    description = product.description,
                };
        }

        public ProductVM GetByName(string name)
        {
            var product = _myDBContext.Products.FirstOrDefault(c => c.name == name);

            if (product == null)
                return null;
            else
                return new ProductVM
                {
                    idPro = product.idPro,
                    name = product.name,
                    idCate = product.idCate,
                    price = product.price,
                    discount = product.discount,
                    description = product.description,
                };
        }

        public ProductVM Update(ProductVM productVM)
        {
            var product = _myDBContext.Products.FirstOrDefault(c => c.idPro == productVM.idPro);

            if (product == null)
                return null;

            product.idPro = productVM.idPro;
            product.name = product.name;
            product.idCate = product.idCate;
            product.price = product.price;
            product.discount = product.discount;
            product.description = product.description;

            _myDBContext.Products.Update(product);
            _myDBContext.SaveChanges();

            return new ProductVM
            {
                idPro = product.idPro,
                name = product.name,
                idCate = product.idCate,
                price = product.price,
                discount = product.discount,
                description = product.description,
            };
        }
    }
}
