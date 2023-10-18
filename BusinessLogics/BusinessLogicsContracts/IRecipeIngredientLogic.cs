using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface IRecipeIngredientLogic
    {
        List<RecipeIngredientVM> Read(RecipeIngredientBM model);
        void CreateOrUpdate(RecipeIngredientBM model);
        void Delete(RecipeIngredientBM model);
    }
}
