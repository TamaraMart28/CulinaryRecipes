using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface ISelectionRecipeLogic
    {
        List<SelectionRecipeVM> Read(SelectionRecipeBM model);
        List<SelectionRecipeVM> ReadByIds(SelectionRecipeBM model);
        void CreateOrUpdate(SelectionRecipeBM model);
        void Delete(SelectionRecipeBM model);
    }
}
