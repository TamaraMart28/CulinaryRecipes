using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.StoragesContracts;
using BusinessLogics.ViewModels;
using BusinessLogics.BindingModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class CategoryStorage : ICategoryStorage
    {
        public List<CategoryVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.Categories
               .Select(rec => new CategoryVM
               {
                   Id = rec.Id,
                   Description = rec.Description
               })
                .ToList();
        }

        public List<CategoryVM> GetFilteredList(CategoryBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.Categories.Where(rec => rec.Description == model.Description)
            .Select(rec => new CategoryVM
            {
                Id = rec.Id,
                Description = rec.Description
            })
            .ToList();
        }


        public CategoryVM GetElement(CategoryBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _el = context.Categories.FirstOrDefault(rec => rec.Id == model.Id || rec.Description == model.Description);
            return _el != null ? new CategoryVM
            {
                Id = _el.Id,
                Description = _el.Description
            } :
            null;
        }

        public void Insert(CategoryBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            context.Categories.Add(CreateModel(model, new Category()));
            context.SaveChanges();
        }

        public void Update(CategoryBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.Categories.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(CategoryBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.Categories.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Categories.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Category CreateModel(CategoryBM model, Category _el)
        {
            _el.Description = model.Description;
            return _el;
        }
    }
}
