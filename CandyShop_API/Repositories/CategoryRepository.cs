using CandyShop_API.Data;
using CandyShop_API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CandyShop_API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDBContext _myDBContext;

        public CategoryRepository(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public CategoryVM Add(string name)
        {
            var cate = new Category {
                name = name,
            };

            _myDBContext.Add(cate);
            _myDBContext.SaveChanges();

            return new CategoryVM
            {
                idCate = cate.idCate,
                name = cate.name,
            };
        }

        public List<CategoryVM> GetAll()
        {
            var list = _myDBContext.Categories.Select(c => new CategoryVM
            {
                idCate = c.idCate,
                name = c.name,
            }).ToList();

            return list;
        }

        public CategoryVM GetByID(int id)
        {
            var cate = _myDBContext.Categories.FirstOrDefault(c => c.idCate == id);

            if (cate == null)
                return null;
            else
                return new CategoryVM
                {
                    idCate = cate.idCate,
                    name = cate.name,
                };
        }

        public CategoryVM GetByName(string name)
        {
            var cate = _myDBContext.Categories.FirstOrDefault(c => c.name == name);

            if (cate == null)
                return null;
            else
                return new CategoryVM
                {
                    idCate = cate.idCate,
                    name = cate.name,
                };
        }

        public CategoryVM Update(CategoryVM category)
        {
            var cate = _myDBContext.Categories.FirstOrDefault(c => c.idCate == category.idCate);

            if (cate == null)
                return null;
            else
            {
                cate.name = category.name;
                _myDBContext.Update(cate);

                return new CategoryVM
                {
                    idCate = cate.idCate,
                    name = cate.name,
                };
            }
        }
    }
}
