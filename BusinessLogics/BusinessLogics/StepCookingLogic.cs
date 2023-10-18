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
    public class StepCookingLogic : IStepCookingLogic
    {
        private readonly IStepCookingStorage _scStorage;

        public StepCookingLogic(IStepCookingStorage scStorage)
        {
            _scStorage = scStorage;
        }

        public List<StepCookingVM> Read(StepCookingBM model)
        {
            if (model == null)
            {
                return _scStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StepCookingVM> { _scStorage.GetElement(model) };
            }
            return _scStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(StepCookingBM model)
        {
            var element = _scStorage.GetElement(new StepCookingBM
            {
                RecipeId = model.RecipeId,
                Description = model.Description
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _scStorage.Update(model);
            }
            else
            {
                _scStorage.Insert(model);
            }
        }

        public void Delete(StepCookingBM model)
        {
            var element = _scStorage.GetElement(new StepCookingBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _scStorage.Delete(model);
        }
    }
}
