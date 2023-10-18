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
    public class RecipeLogic : IRecipeLogic
    {
        private readonly IRecipeStorage _rStorage;

        public RecipeLogic(IRecipeStorage rStorage)
        {
            _rStorage = rStorage;
        }

        public List<RecipeVM> Read(RecipeBM model)
        {
            if (model == null)
            {
                return _rStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<RecipeVM> { _rStorage.GetElement(model) };
            }
            return _rStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(RecipeBM model)
        {
            var element = _rStorage.GetElement(new RecipeBM
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _rStorage.Update(model);
            }
            else
            {
                _rStorage.Insert(model);
            }
        }

        public void Delete(RecipeBM model)
        {
            var element = _rStorage.GetElement(new RecipeBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _rStorage.Delete(model);
        }
    }
}
