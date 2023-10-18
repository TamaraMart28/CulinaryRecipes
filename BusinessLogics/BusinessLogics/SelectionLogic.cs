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
    public class SelectionLogic : ISelectionLogic
    {
        private readonly ISelectionStorage _selStorage;

        public SelectionLogic(ISelectionStorage selStorage)
        {
            _selStorage = selStorage;
        }

        public List<SelectionVM> Read(SelectionBM model)
        {
            if (model == null)
            {
                return _selStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SelectionVM> { _selStorage.GetElement(model) };
            }
            return _selStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SelectionBM model)
        {
            var element = _selStorage.GetElement(new SelectionBM
            {
                UserId = model.UserId,
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _selStorage.Update(model);
            }
            else
            {
                _selStorage.Insert(model);
            }
        }

        public void Delete(SelectionBM model)
        {
            var element = _selStorage.GetElement(new SelectionBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _selStorage.Delete(model);
        }
    }
}
