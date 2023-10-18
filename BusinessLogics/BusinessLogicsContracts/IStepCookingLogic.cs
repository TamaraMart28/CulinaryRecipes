using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface IStepCookingLogic
    {
        List<StepCookingVM> Read(StepCookingBM model);
        void CreateOrUpdate(StepCookingBM model);
        void Delete(StepCookingBM model);
    }
}
