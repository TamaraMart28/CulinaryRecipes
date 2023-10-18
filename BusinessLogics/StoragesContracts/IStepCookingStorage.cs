using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface IStepCookingStorage
    {
        List<StepCookingVM> GetFullList();
        List<StepCookingVM> GetFilteredList(StepCookingBM model);
        StepCookingVM GetElement(StepCookingBM model);
        void Insert(StepCookingBM model);
        void Update(StepCookingBM model);
        void Delete(StepCookingBM model);
    }
}
