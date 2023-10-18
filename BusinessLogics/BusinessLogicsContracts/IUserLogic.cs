using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface IUserLogic
    {
        List<UserVM> Read(UserBM model);
        void CreateOrUpdate(UserBM model);
        void Delete(UserBM model);
    }
}
