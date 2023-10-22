using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogics.BindingModels;
using BusinessLogics.BusinessLogicsContracts;
using BusinessLogics.ViewModels;

namespace RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IUserLogic _userLogic;


        public MainController(IUserLogic userLogic)
        {
            _userLogic = userLogic;

        }

        //USER
        //Регистрация
        [HttpPost]
        public void RegisterUser(UserBM model) => _userLogic.CreateOrUpdate(model);

        //Авторизация
        [HttpGet]
        public UserVM LoginUser(string login, string password)
        {
            var list = _userLogic.Read(new UserBM
            {
                Login = login,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        //Изменение пользователя
        [HttpPost]
        public void UpdateUser(UserBM model) => _userLogic.CreateOrUpdate(model);

        //Список всех пользователей
        [HttpGet]
        public List<UserVM> GetUserList() => _userLogic.Read(null)?.ToList();

        //Пользователь по логину
        [HttpGet]
        public UserVM GetUser(string login)
        {
            var list = _userLogic.Read(new UserBM
            {
                Login = login,
                Password = null
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

    }
}
