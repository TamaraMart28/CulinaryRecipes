using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface IRecipeStorage
    {
        List<RecipeVM> GetFullList();
        List<RecipeVM> GetFilteredList(RecipeBM model);
        RecipeVM GetElement(RecipeBM model);
        void Insert(RecipeBM model);
        void Update(RecipeBM model);
        void Delete(RecipeBM model);
    }
}
