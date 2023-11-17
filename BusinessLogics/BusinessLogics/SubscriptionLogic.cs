using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using BusinessLogics.StoragesContracts;
using BusinessLogics.BusinessLogicsContracts;

namespace BusinessLogics.BusinessLogics
{
    public class SubscriptionLogic : ISubscriptionLogic
    {
        private readonly ISubscriptionStorage _subStorage;

        public SubscriptionLogic(ISubscriptionStorage sStorage)
        {
            _subStorage = sStorage;
        }

        public List<SubscriptionVM> Read(SubscriptionBM model)
        {
            if (model == null)
            {
                return _subStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SubscriptionVM> { _subStorage.GetElement(model) };
            }
            return _subStorage.GetFilteredList(model);
        }

        public List<SubscriptionVM> ReadByIds(SubscriptionBM model)
        {
            if (model == null)
            {
                return _subStorage.GetFullList();
            }
            return new List<SubscriptionVM> { _subStorage.GetElementByIds(model) };
        }

        public void CreateOrUpdate(SubscriptionBM model)
        {
            var element = _subStorage.GetElement(new SubscriptionBM
            {
                UserIdFollower = model.UserIdFollower,
                UserIdFollowing = model.UserIdFollowing
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _subStorage.Update(model);
            }
            else
            {
                _subStorage.Insert(model);
            }
        }

        public void Delete(SubscriptionBM model)
        {
            var element = _subStorage.GetElement(new SubscriptionBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _subStorage.Delete(model);
        }
    }
}
