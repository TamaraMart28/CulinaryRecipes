using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using BusinessLogics.StoragesContracts;
using BusinessLogics.BusinessLogicsContracts;

namespace BusinessLogics.BusinessLogics
{
    public class RecipeIngredientLogic : IRecipeIngredientLogic
    {
        private readonly IRecipeIngredientStorage _riStorage;

        public RecipeIngredientLogic(IRecipeIngredientStorage riStorage)
        {
            _riStorage = riStorage;
        }

        public List<RecipeIngredientVM> Read(RecipeIngredientBM model)
        {
            if (model == null)
            {
                return _riStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<RecipeIngredientVM> { _riStorage.GetElement(model) };
            }
            return _riStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(RecipeIngredientBM model)
        {
            var element = _riStorage.GetElement(new RecipeIngredientBM
            {
                RecipeId = model.RecipeId,
                IngredientId = model.IngredientId
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _riStorage.Update(model);
            }
            else
            {
                _riStorage.Insert(model);
            }
        }

        public void Delete(RecipeIngredientBM model)
        {
            var element = _riStorage.GetElement(new RecipeIngredientBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _riStorage.Delete(model);
        }
    }
}
