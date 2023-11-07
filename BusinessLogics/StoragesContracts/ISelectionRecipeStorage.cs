using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface ISelectionRecipeStorage
    {
        List<SelectionRecipeVM> GetFullList();
        List<SelectionRecipeVM> GetFilteredList(SelectionRecipeBM model);
        SelectionRecipeVM GetElement(SelectionRecipeBM model);
        SelectionRecipeVM GetElementByIds(SelectionRecipeBM model);
        void Insert(SelectionRecipeBM model);
        void Update(SelectionRecipeBM model);
        void Delete(SelectionRecipeBM model);
    }
}
