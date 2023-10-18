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
    public class IngredientStorage : IIngredientStorage
    {
        public List<IngredientVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.Ingredients
               .Select(rec => new IngredientVM
               {
                   Id = rec.Id,
                   Name = rec.Name
               })
                .ToList();
        }

        public List<IngredientVM> GetFilteredList(IngredientBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.Ingredients.Where(rec => rec.Name == model.Name)
            .Select(rec => new IngredientVM
            {
                Id = rec.Id,
                Name = rec.Name
            })
            .ToList();
        }


        public IngredientVM GetElement(IngredientBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _el = context.Ingredients.FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
            return _el != null ? new IngredientVM
            {
                Id = _el.Id,
                Name = _el.Name
            } :
            null;
        }

        public void Insert(IngredientBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            context.Ingredients.Add(CreateModel(model, new Ingredient()));
            context.SaveChanges();
        }

        public void Update(IngredientBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.Ingredients.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(IngredientBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.Ingredients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Ingredients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Ingredient CreateModel(IngredientBM model, Ingredient _el)
        {
            _el.Name = model.Name;
            return _el;
        }
    }
}
