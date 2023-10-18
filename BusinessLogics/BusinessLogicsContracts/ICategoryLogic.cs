using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface ICategoryLogic
    {
        List<CategoryVM> Read(CategoryBM model);
        void CreateOrUpdate(CategoryBM model);
        void Delete(CategoryBM model);
    }
}
