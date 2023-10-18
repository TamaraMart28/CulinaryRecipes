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
    public class RecipeStorage : IRecipeStorage
    {
        public List<RecipeVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.Recipes.ToList()
               .Select(CreateModel)
                .ToList();
        }

        public List<RecipeVM> GetFilteredList(RecipeBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.Recipes.Where(rec => rec.CategoryId == model.CategoryId || rec.UserId == model.UserId)
            .ToList().Select(CreateModel)
           .ToList();
        }

        public RecipeVM GetElement(RecipeBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var el = context.Recipes.FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
            return el != null ? CreateModel(el) : null;
        }

        public void Insert(RecipeBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            using var transaction = context.Database.BeginTransaction();

            try
            {
                Recipe el = new Recipe
                {
                    Name = model.Name,
                    Description = model.Description,
                    Timing = model.Timing,
                    PortionAmount = model.PortionAmount,
                    CategoryId = model.CategoryId,
                    UserId = model.UserId
                };
                context.Recipes.Add(el);
                context.SaveChanges();
                CreateModel(model, el, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(RecipeBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            using var transaction = context.Database.BeginTransaction();

            try
            {
                var element = context.Recipes.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(RecipeBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            Recipe element = context.Recipes.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Recipes.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Recipe CreateModel(RecipeBM model, Recipe el, CulinaryRecipesDatabase context)//
        {
            el.Name = model.Name;
            el.Description = model.Description;
            el.Timing = model.Timing;
            el.PortionAmount = model.PortionAmount;
            el.CategoryId = model.CategoryId;
            el.UserId = model.UserId;

            return el;
        }

        private static RecipeVM CreateModel(Recipe el)
        {
            return new RecipeVM
            {
                Id = el.Id,
                Name = el.Name,
                Description = el.Description,
                Timing = el.Timing,
                PortionAmount = el.PortionAmount,
                CategoryId = el.CategoryId,
                UserId = el.UserId,
                StepCookings = el.StepCookings != null ? el.StepCookings.ToDictionary(rec => rec.Id, rec => (rec.Description)) : null,
                RecipeIngredients = el.RecipeIngredients != null ? el.RecipeIngredients.ToDictionary(rec => rec.Id.Value, rec => (rec.Ingredient.Name)) : null,
                CommentGrades = el.CommentGrades != null ? el.CommentGrades.ToDictionary(rec => rec.Id, rec => (rec.Comment + ", " + rec.Grade)) : null,
            };
        }
    }
}
