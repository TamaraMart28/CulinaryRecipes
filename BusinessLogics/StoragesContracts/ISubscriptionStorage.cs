using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface ISubscriptionStorage
    {
        List<SubscriptionVM> GetFullList();
        List<SubscriptionVM> GetFilteredList(SubscriptionBM model);
        SubscriptionVM GetElement(SubscriptionBM model);
        void Insert(SubscriptionBM model);
        void Update(SubscriptionBM model);
        void Delete(SubscriptionBM model);
    }
}
