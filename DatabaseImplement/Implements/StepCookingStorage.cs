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
    public class StepCookingStorage : IStepCookingStorage
    {
        public List<StepCookingVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.StepCookings
               .Select(rec => new StepCookingVM
               {
                   Id = rec.Id,
                   NumberOrder = rec.NumberOrder,
                   Description = rec.Description,
                   ImageName = rec.ImageName,
                   ImagePath = rec.ImagePath,
                   RecipeId = rec.RecipeId
               })
                .ToList();
        }

        public List<StepCookingVM> GetFilteredList(StepCookingBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.StepCookings.Where(rec => rec.RecipeId == model.RecipeId)
            .Select(rec => new StepCookingVM
            {
                Id = rec.Id,
                NumberOrder = rec.NumberOrder,
                Description = rec.Description,
                ImageName = rec.ImageName,
                ImagePath = rec.ImagePath,
                RecipeId = rec.RecipeId
            })
            .ToList();
        }


        public StepCookingVM GetElement(StepCookingBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _el = context.StepCookings.FirstOrDefault(rec => rec.Id == model.Id || rec.RecipeId == model.RecipeId);
            return _el != null ? new StepCookingVM
            {
                Id = _el.Id,
                NumberOrder = _el.NumberOrder,
                Description = _el.Description,
                ImageName = _el.ImageName,
                ImagePath = _el.ImagePath,
                RecipeId = _el.RecipeId
            } :
            null;
        }

        public void Insert(StepCookingBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            context.StepCookings.Add(CreateModel(model, new StepCooking()));
            context.SaveChanges();
        }

        public void Update(StepCookingBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.StepCookings.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(StepCookingBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.StepCookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.StepCookings.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private StepCooking CreateModel(StepCookingBM model, StepCooking _el)
        {
            _el.NumberOrder = model.NumberOrder;
            _el.Description = model.Description;
            _el.ImageName = model.ImageName;
            _el.ImagePath = model.ImagePath;
            _el.RecipeId = model.RecipeId;
            return _el;
        }
    }
}
