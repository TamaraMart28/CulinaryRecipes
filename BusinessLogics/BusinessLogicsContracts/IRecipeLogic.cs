using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface IRecipeLogic
    {
        List<RecipeVM> Read(RecipeBM model);
        void CreateOrUpdate(RecipeBM model);
        void Delete(RecipeBM model);
    }
}
