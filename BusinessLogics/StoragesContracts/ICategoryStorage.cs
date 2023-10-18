using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface ICategoryStorage
    {
        List<CategoryVM> GetFullList();
        List<CategoryVM> GetFilteredList(CategoryBM model);
        CategoryVM GetElement(CategoryBM model);
        void Insert(CategoryBM model);
        void Update(CategoryBM model);
        void Delete(CategoryBM model);
    }
}
