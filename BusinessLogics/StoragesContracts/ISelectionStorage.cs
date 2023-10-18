using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface ISelectionStorage
    {
        List<SelectionVM> GetFullList();
        List<SelectionVM> GetFilteredList(SelectionBM model);
        SelectionVM GetElement(SelectionBM model);
        void Insert(SelectionBM model);
        void Update(SelectionBM model);
        void Delete(SelectionBM model);
    }
}
