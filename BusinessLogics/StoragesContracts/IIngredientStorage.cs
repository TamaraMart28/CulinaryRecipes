using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface IIngredientStorage
    {
        List<IngredientVM> GetFullList();
        List<IngredientVM> GetFilteredList(IngredientBM model);
        IngredientVM GetElement(IngredientBM model);
        void Insert(IngredientBM model);
        void Update(IngredientBM model);
        void Delete(IngredientBM model);
    }
}
