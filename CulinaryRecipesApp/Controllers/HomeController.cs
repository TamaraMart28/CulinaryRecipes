using CulinaryRecipesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using System.Text.RegularExpressions;
using System.IO;

namespace CulinaryRecipesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly int _passwordMaxLength = 50;
        private readonly int _passwordMinLength = 5;


        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        //Главная страница
        public IActionResult Index()
        {
            return View();
        }

        //Личный кабинет
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(string nickname, string password, IFormFile uploadedFile)
        {
            try
            {
                var el = APIClient.GetRequest<UserVM>($"api/main/getuser?login={Session.User.Login}");

                //Работа с аватаром
                string path;
                string imageName;
                if (uploadedFile == null)
                {
                    imageName = el.AvatarName;
                    path = el.AvatarPath;
                }
                else
                {
                    if(!(el.AvatarName == "noimage" && el.AvatarPath == "noimage"))
                    {
                        if (System.IO.File.Exists(_environment.WebRootPath + el.AvatarPath))
                        {
                            System.IO.File.Delete(_environment.WebRootPath + el.AvatarPath);
                        }
                    }
                    path = "/Files/" + uploadedFile.FileName;
                    imageName = uploadedFile.FileName;
                    using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                }
                //Работа с паролем
                if (password.Length > _passwordMaxLength || password.Length < _passwordMinLength
                    || !Regex.IsMatch(password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
                {
                    throw new Exception($"Пароль длиной от {_passwordMinLength} до { _passwordMaxLength } должен состоять из цифр, букв и небуквенных символов");
                }

                if (!string.IsNullOrEmpty(nickname) && !string.IsNullOrEmpty(password))
                {
                    APIClient.PostRequest("api/main/updateuser", new UserBM
                    {
                        Id = Session.User.Id,
                        Login = Session.User.Login,
                        Password = password,
                        Nickname = nickname,
                        AvatarName = imageName,
                        AvatarPath = path,
                        Recipes = new Dictionary<int, string>(),
                        Selections = new Dictionary<int, string>(),
                        CommentGrades = new Dictionary<int, string>(),
                        SubscriptionFollowers = new Dictionary<int, string>(),
                        SubscriptionFollowings = new Dictionary<int, string>()
                    });
                    Session.User.Nickname = nickname;
                    Session.User.Password = password;
                    Session.User.AvatarName = imageName;
                    Session.User.AvatarPath = path;
                    return Redirect("Privacy");
                }
                throw new Exception("Введите никнейм и пароль");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Redirect("Privacy");
            }
        }

        //Регистрация пользователя
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(string login, string password, string nickname, IFormFile uploadedFile)
        {
            try
            {
                //Работа с аватаром
                string path;
                string imageName;
                if (uploadedFile == null)
                {
                    imageName = "noimage";
                    path = "noimage";
                }
                else
                {
                    path = "/Files/" + uploadedFile.FileName;
                    imageName = uploadedFile.FileName;
                    using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                }

                //Обработка исключений
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nickname))
                {
                    throw new Exception("Введите логин, пароль и никнейм");
                }
                var elem = APIClient.GetRequest<UserVM>($"api/main/getuser?login={login}");
                if (login != null && elem != null && login == elem.Login)
                {
                    throw new Exception("Учетная запись по такому логину уже существует");
                }
                if (!Regex.IsMatch(login, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    throw new Exception("В качестве логина должна быть указана почта");
                }
                if (password.Length > _passwordMaxLength || password.Length < _passwordMinLength
                    || !Regex.IsMatch(password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
                {
                    throw new Exception($"Пароль длиной от {_passwordMinLength} до { _passwordMaxLength } должен состоять из цифр, букв и небуквенных символов");
                }

                //Регистрация
                APIClient.PostRequest("api/main/registeruser", new UserBM
                {
                    Nickname = nickname,
                    Login = login,
                    Password = password,
                    AvatarName = imageName,
                    AvatarPath = path,
                    Recipes = new Dictionary<int, string>(),
                    Selections = new Dictionary<int, string>(),
                    CommentGrades = new Dictionary<int, string>(),
                    SubscriptionFollowers = new Dictionary<int, string>(),
                    SubscriptionFollowings = new Dictionary<int, string>()
                });
                TempData["Message"] = "Регистрация прошла успешно!";
                return Redirect("LoginUser");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Redirect("RegisterUser");
            }
        }

        //Авторизация пользователя
        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public void LoginUser(string login, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
                {
                    Session.User = APIClient.GetRequest<UserVM>($"api/main/loginuser?login={login}&password={password}");
                    if (Session.User == null)
                    {
                        throw new Exception("Неверный логин/пароль");
                    }
                    Response.Redirect("Index");
                    return;
                }
                throw new Exception("Введите логин и пароль");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                Response.Redirect("LoginUser");
                return;
            }
        }












        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}