using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface ISelectionLogic
    {
        List<SelectionVM> Read(SelectionBM model);
        void CreateOrUpdate(SelectionBM model);
        void Delete(SelectionBM model);
    }
}
