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
    public class UserStorage : IUserStorage
    {
        public List<UserVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.Users.ToList()
               .Select(CreateModel)
                .ToList();
        }

        public List<UserVM> GetFilteredList(UserBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.Users.Where(rec => rec.Login == model.Login && rec.Password == rec.Password)
            .ToList().Select(CreateModel)
           .ToList();
        }

        public UserVM GetElement(UserBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var el = context.Users.FirstOrDefault(rec => rec.Id == model.Id || rec.Login == model.Login);
            return el != null ? CreateModel(el) : null;
        }

        public void Insert(UserBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            using var transaction = context.Database.BeginTransaction();

            try
            {
                User el = new User
                {
                    Login = model.Login,
                    Password = model.Password,
                    Nickname = model.Nickname,
                    AvatarName = model.AvatarName,
                    AvatarPath = model.AvatarPath
                };
                context.Users.Add(el);
                context.SaveChanges();
                CreateModel(model, el, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(UserBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            using var transaction = context.Database.BeginTransaction();

            try
            {
                var element = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Delete(UserBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            User element = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Users.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private User CreateModel(UserBM model, User el, CulinaryRecipesDatabase context)//
        {
            el.Login = model.Login;
            el.Password = model.Password;
            el.Nickname = model.Nickname;
            el.AvatarPath = model.AvatarPath;
            el.AvatarName = model.AvatarName;

            return el;
        }

        private static UserVM CreateModel(User el)
        {
            return new UserVM
            {
                Id = el.Id,
                Login = el.Login,
                Password = el.Password,
                Nickname = el.Nickname,
                AvatarName = el.AvatarName,
                AvatarPath = el.AvatarPath,
                Recipes = el.Recipes != null ? el.Recipes.ToDictionary(rec => rec.Id, rec => (rec.Name)) : null,
                Selections = el.Selections != null ? el.Selections.ToDictionary(rec => rec.Id, rec => (rec.Name)) : null,
                CommentGrades = el.CommentGrades != null ? el.CommentGrades.ToDictionary(rec => rec.Id, rec => (rec.Comment + ", " + rec.Grade)) : null,
                SubscriptionFollowers = el.SubscriptionFollowers != null ? el.SubscriptionFollowers.ToDictionary(rec => rec.Id, rec => (rec.UserFollower.Nickname)) : null,
                SubscriptionFollowings = el.SubscriptionFollowings != null ? el.SubscriptionFollowings.ToDictionary(rec => rec.Id, rec => (rec.UserFollowing.Nickname)) : null
            };
        }
    }
}
