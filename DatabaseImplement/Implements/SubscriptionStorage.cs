using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.StoragesContracts;
using BusinessLogics.ViewModels;
using BusinessLogics.BindingModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class SubscriptionStorage : ISubscriptionStorage
    {
        public List<SubscriptionVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.Subscriptions
               .Select(rec => new SubscriptionVM
               {
                   Id = rec.Id,
                   UserIdFollower = rec.UserIdFollower,
                   UserIdFollowing = rec.UserIdFollowing
               })
                .ToList();
        }

        public List<SubscriptionVM> GetFilteredList(SubscriptionBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.Subscriptions.Where(rec => rec.UserIdFollower == model.UserIdFollower || rec.UserIdFollowing == model.UserIdFollowing)
            .Select(rec => new SubscriptionVM
            {
                Id = rec.Id,
                UserIdFollower = rec.UserIdFollower,
                UserIdFollowing = rec.UserIdFollowing
            })
            .ToList();
        }


        public SubscriptionVM GetElement(SubscriptionBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _el = context.Subscriptions.FirstOrDefault(rec => rec.Id == model.Id);
            return _el != null ? new SubscriptionVM
            {
                Id = _el.Id,
                UserIdFollower = _el.UserIdFollower,
                UserIdFollowing = _el.UserIdFollowing
            } :
            null;
        }

        public SubscriptionVM GetElementByIds(SubscriptionBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _fb = context.Subscriptions.FirstOrDefault(rec => rec.UserIdFollower == model.UserIdFollower && rec.UserIdFollowing == model.UserIdFollowing);
            return _fb != null ? new SubscriptionVM
            {
                Id = (int)_fb.Id,
                UserIdFollower = _fb.UserIdFollower,
                UserIdFollowing = _fb.UserIdFollowing
            } :
            null;
        }

        public void Insert(SubscriptionBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            context.Subscriptions.Add(CreateModel(model, new Subscription()));
            context.SaveChanges();
        }

        public void Update(SubscriptionBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.Subscriptions.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(SubscriptionBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.Subscriptions.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Subscriptions.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Subscription CreateModel(SubscriptionBM model, Subscription _el)
        {
            _el.UserIdFollower = model.UserIdFollower;
            _el.UserIdFollowing = model.UserIdFollowing;
            return _el;
        }
    }
}
