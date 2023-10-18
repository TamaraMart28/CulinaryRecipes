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
    public class SelectionRecipeLogic : ISelectionRecipeLogic
    {
        private readonly ISelectionRecipeStorage _srStorage;

        public SelectionRecipeLogic(ISelectionRecipeStorage srStorage)
        {
            _srStorage = srStorage;
        }

        public List<SelectionRecipeVM> Read(SelectionRecipeBM model)
        {
            if (model == null)
            {
                return _srStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SelectionRecipeVM> { _srStorage.GetElement(model) };
            }
            return _srStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SelectionRecipeBM model)
        {
            var element = _srStorage.GetElement(new SelectionRecipeBM
            {
                SelectionId = model.SelectionId,
                RecipeId = model.RecipeId
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _srStorage.Update(model);
            }
            else
            {
                _srStorage.Insert(model);
            }
        }

        public void Delete(SelectionRecipeBM model)
        {
            var element = _srStorage.GetElement(new SelectionRecipeBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _srStorage.Delete(model);
        }
    }
}
