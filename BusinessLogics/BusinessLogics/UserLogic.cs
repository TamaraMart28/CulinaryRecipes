using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using BusinessLogics.StoragesContracts;
using BusinessLogics.BusinessLogicsContracts;
using System.Text.RegularExpressions;

namespace BusinessLogics.BusinessLogics
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserStorage _userStorage;
        private readonly int _passwordMaxLength = 50;
        private readonly int _passwordMinLength = 5;

        public UserLogic(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public List<UserVM> Read(UserBM model)
        {
            if (model == null)
            {
                return _userStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<UserVM> { _userStorage.GetElement(model) };
            }
            return _userStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(UserBM model)
        {
            //var elementByLogin = _userStorage.GetElement(new UserBM
            //{
            //    Login = model.Login
            //});
            //if (elementByLogin != null && elementByLogin.Id != model.Id)
            //{
            //    throw new Exception("Учетная запись по такому логину уже существует");
            //}
            //if (!Regex.IsMatch(model.Login, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            //    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
            //{
            //    throw new Exception("В качестве логина должна быть указана почта");
            //}
            //if (model.Password.Length > _passwordMaxLength || model.Password.Length < _passwordMinLength
            //    || !Regex.IsMatch(model.Password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            //{
            //    throw new Exception($"Пароль длиной от {_passwordMinLength} до { _passwordMaxLength } должен состоять из цифр, букв и небуквенных символов");
            //}
            if (model.Id.HasValue)
            {
                _userStorage.Update(model);
            }
            else
            {
                _userStorage.Insert(model);
            }
        }

        public void Delete(UserBM model)
        {
            var element = _userStorage.GetElement(new UserBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _userStorage.Delete(model);
        }
    }
}
