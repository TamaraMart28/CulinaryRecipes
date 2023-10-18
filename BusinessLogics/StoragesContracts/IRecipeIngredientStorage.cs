using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface IRecipeIngredientStorage
    {
        List<RecipeIngredientVM> GetFullList();
        List<RecipeIngredientVM> GetFilteredList(RecipeIngredientBM model);
        RecipeIngredientVM GetElement(RecipeIngredientBM model);
        void Insert(RecipeIngredientBM model);
        void Update(RecipeIngredientBM model);
        void Delete(RecipeIngredientBM model);
    }
}
