using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface ISubscriptionLogic
    {
        List<SubscriptionVM> Read(SubscriptionBM model);
        List<SubscriptionVM> ReadByIds(SubscriptionBM model);
        void CreateOrUpdate(SubscriptionBM model);
        void Delete(SubscriptionBM model);
    }
}
