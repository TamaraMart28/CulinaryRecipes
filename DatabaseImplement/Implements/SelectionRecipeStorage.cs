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
    public class SelectionRecipeStorage : ISelectionRecipeStorage
    {
        public List<SelectionRecipeVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.SelectionRecipes
               .Select(rec => new SelectionRecipeVM
               {
                   Id = (int)rec.Id,
                   SelectionId = rec.SelectionId,
                   RecipeId = rec.RecipeId
               })
               .ToList();
        }

        public List<SelectionRecipeVM> GetFilteredList(SelectionRecipeBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.SelectionRecipes.Where(rec => rec.SelectionId == model.SelectionId)
            .Select(rec => new SelectionRecipeVM
            {
                Id = (int)rec.Id,
                SelectionId = rec.SelectionId,
                RecipeId = rec.RecipeId
            })
            .ToList();
        }

        public SelectionRecipeVM GetElement(SelectionRecipeBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _bb = context.SelectionRecipes.FirstOrDefault(rec => rec.Id == model.Id);
            return _bb != null ? new SelectionRecipeVM
            {
                Id = (int)_bb.Id,
                SelectionId = _bb.SelectionId,
                RecipeId = _bb.RecipeId
            } :
            null;
        }

        public SelectionRecipeVM GetElementByIds(SelectionRecipeBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _fb = context.SelectionRecipes.FirstOrDefault(rec => rec.RecipeId == model.RecipeId && rec.SelectionId == model.SelectionId);
            return _fb != null ? new SelectionRecipeVM
            {
                Id = (int)_fb.Id,
                RecipeId = _fb.RecipeId,
                SelectionId = _fb.SelectionId
            } :
            null;
        }

        public void Insert(SelectionRecipeBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            context.SelectionRecipes.Add(CreateModel(model, new SelectionRecipe()));

            context.SaveChanges();
        }

        public void Update(SelectionRecipeBM model)//to do
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

        public void Delete(SelectionRecipeBM model)//to do
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.SelectionRecipes.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.SelectionRecipes.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Филиал не найден");
            }
        }

        private SelectionRecipe CreateModel(SelectionRecipeBM model, SelectionRecipe _sr)// to do
        {
            _sr.RecipeId = model.RecipeId;
            _sr.SelectionId = model.SelectionId;
            return _sr;
        }
    }
}
