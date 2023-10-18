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
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryStorage _cStorage;

        public CategoryLogic(ICategoryStorage cStorage)
        {
            _cStorage = cStorage;
        }

        public List<CategoryVM> Read(CategoryBM model)
        {
            if (model == null)
            {
                return _cStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CategoryVM> { _cStorage.GetElement(model) };
            }
            return _cStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CategoryBM model)
        {
            var element = _cStorage.GetElement(new CategoryBM
            {
                Description = model.Description
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _cStorage.Update(model);
            }
            else
            {
                _cStorage.Insert(model);
            }
        }

        public void Delete(CategoryBM model)
        {
            var element = _cStorage.GetElement(new CategoryBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _cStorage.Delete(model);
        }
    }
}
