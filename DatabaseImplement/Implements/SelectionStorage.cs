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
    public class SelectionStorage : ISelectionStorage
    {
        public List<SelectionVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.Selections
               .Select(rec => new SelectionVM
               {
                   Id = rec.Id,
                   Name = rec.Name,
                   IsPrivate = rec.IsPrivate,
                   UserId = rec.UserId
               })
                .ToList();
        }

        public List<SelectionVM> GetFilteredList(SelectionBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.Selections.Where(rec => (rec.Name == model.Name && rec.UserId == model.UserId) || (model.Name == "" && rec.UserId == model.UserId))
            .Select(rec => new SelectionVM
            {
                Id = rec.Id,
                Name = rec.Name,
                IsPrivate = rec.IsPrivate,
                UserId = rec.UserId
            })
            .ToList();
        }

        public SelectionVM GetElement(SelectionBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _el = context.Selections.FirstOrDefault(rec => rec.Id == model.Id);
            return _el != null ? new SelectionVM
            {
                Id = _el.Id,
                Name = _el.Name,
                IsPrivate = _el.IsPrivate,
                UserId = _el.UserId
            } : null;
        }

        public void Insert(SelectionBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            context.Selections.Add(CreateModel(model, new Selection()));
            context.SaveChanges();
        }

        public void Update(SelectionBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.Selections.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(SelectionBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.Selections.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Selections.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Selection CreateModel(SelectionBM model, Selection _el)
        {
            _el.Name = model.Name;
            _el.IsPrivate = model.IsPrivate;
            _el.UserId = model.UserId;
            return _el;
        }
    }
}
