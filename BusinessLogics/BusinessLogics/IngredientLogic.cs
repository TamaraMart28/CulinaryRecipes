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
    public class IngredientLogic : IIngredientLogic
    {
        private readonly IIngredientStorage _iStorage;

        public IngredientLogic(IIngredientStorage iStorage)
        {
            _iStorage = iStorage;
        }

        public List<IngredientVM> Read(IngredientBM model)
        {
            if (model == null)
            {
                return _iStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<IngredientVM> { _iStorage.GetElement(model) };
            }
            return _iStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(IngredientBM model)
        {
            var element = _iStorage.GetElement(new IngredientBM
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _iStorage.Update(model);
            }
            else
            {
                _iStorage.Insert(model);
            }
        }

        public void Delete(IngredientBM model)
        {
            var element = _iStorage.GetElement(new IngredientBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _iStorage.Delete(model);
        }
    }
}
