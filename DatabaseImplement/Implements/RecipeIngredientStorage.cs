using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.StoragesContracts;
using BusinessLogics.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class RecipeIngredientStorage : IRecipeIngredientStorage
    {
        public List<RecipeIngredientVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.RecipeIngredients
               .Select(rec => new RecipeIngredientVM
               {
                   Id = (int)rec.Id,
                   RecipeId = rec.RecipeId,
                   IngredientId = rec.IngredientId,
                   Amount = rec.Amount
               })
               .ToList();
        }

        public List<RecipeIngredientVM> GetFilteredList(RecipeIngredientBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.RecipeIngredients.Where(rec => rec.RecipeId == model.RecipeId)
            .Select(rec => new RecipeIngredientVM
            {
                Id = (int)rec.Id,
                RecipeId = rec.RecipeId,
                IngredientId = rec.IngredientId,
                Amount = rec.Amount
            })
            .ToList();
        }

        public RecipeIngredientVM GetElement(RecipeIngredientBM model)//to do
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _el = context.RecipeIngredients.FirstOrDefault(rec => rec.Id == model.Id);
            return _el != null ? new RecipeIngredientVM
            {
                Id = (int)_el.Id
            } :
            null;
        }

        public void Insert(RecipeIngredientBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            context.RecipeIngredients.Add(CreateModel(model, new RecipeIngredient()));

            context.SaveChanges();
        }

        public void Update(RecipeIngredientBM model)//to do
        {
            //using var context = new LibraryDatabase();

            //var element = context.ReaderBooks.FirstOrDefault(rec => rec.Id == model.Id);

            //if (element == null)
            //{
            //    throw new Exception("Элемент не найден");
            //}
            //CreateModel(model, element);
            //context.SaveChanges();
        }

        public void Delete(RecipeIngredientBM model)//to do
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.RecipeIngredients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.RecipeIngredients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private RecipeIngredient CreateModel(RecipeIngredientBM model, RecipeIngredient _ri)// to do
        {
            _ri.RecipeId = model.RecipeId;
            _ri.IngredientId = model.IngredientId;
            _ri.Amount = model.Amount;
            return _ri;
        }
    }
}
