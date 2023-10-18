using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface IIngredientLogic
    {
        List<IngredientVM> Read(IngredientBM model);
        void CreateOrUpdate(IngredientBM model);
        void Delete(IngredientBM model);
    }
}
