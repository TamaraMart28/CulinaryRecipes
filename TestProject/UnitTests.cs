using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using BusinessLogics.BusinessLogicsContracts;
using System.Collections.Generic;
using RestApi.Controllers;
using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class UnitTests
    {
        private Mock<IConfiguration> mockConfiguration;
        private HttpClient httpClient;


        Mock<IUserLogic> mockUserLogic;
        Mock<IRecipeLogic> mockRecipeLogic;
        Mock<ICategoryLogic> mockCategoryLogic;
        Mock<IRecipeIngredientLogic> mockRiLogic;
        Mock<IStepCookingLogic> mockScLogic;
        Mock<IIngredientLogic> mockIngrLogic;
        Mock<ICommentGradeLogic> mockCgLogic;
        Mock<ISelectionLogic> mockSelectionLogic;
        Mock<ISelectionRecipeLogic> mockSrLogic;
        Mock<ISubscriptionLogic> mockSubLogic;
        private MainController controller;


        [TestInitialize]
        public void Setup()
        {
            mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(c => c["IPAddress"]).Returns("https://localhost:7214");

            httpClient = new HttpClient();
            CulinaryRecipesApp.APIClient.Connect(mockConfiguration.Object);



            //mockConfiguration = new Mock<IConfiguration>();
            //mockConfiguration.Setup(c => c["IPAddress"]).Returns("http://example.com");

            //var handlerStub = new HttpMessageHandlerStub(new HttpResponseMessage
            //{
            //    StatusCode = HttpStatusCode.OK,
            //    Content = new StringContent("{\"success\": true}")
            //});

            //httpClient = new HttpClient(handlerStub);
            //CulinaryRecipesApp.APIClient.Connect(mockConfiguration.Object);


            mockUserLogic = new Mock<IUserLogic>();
            mockRecipeLogic = new Mock<IRecipeLogic>();
            mockCategoryLogic = new Mock<ICategoryLogic>();
            mockRiLogic = new Mock<IRecipeIngredientLogic>();
            mockScLogic = new Mock<IStepCookingLogic>();
            mockIngrLogic = new Mock<IIngredientLogic>();
            mockCgLogic = new Mock<ICommentGradeLogic>();
            mockSelectionLogic = new Mock<ISelectionLogic>();
            mockSrLogic = new Mock<ISelectionRecipeLogic>();
            mockSubLogic = new Mock<ISubscriptionLogic>();
            // Инициализация других моков для зависимостей, если необходимо

            controller = new MainController(
                mockUserLogic.Object, mockRecipeLogic.Object, mockCategoryLogic.Object,
                mockRiLogic.Object, mockScLogic.Object, mockIngrLogic.Object,
                mockCgLogic.Object, mockSelectionLogic.Object, mockSrLogic.Object,
                mockSubLogic.Object);

        }

        ////public UnitTests()
        ////{
        ////    //CulinaryRecipesApp.APIClient.Connect(app.Configuration);
        ////    HomeController contr = new HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment);
        ////}

        ////[TestMethod]
        ////public void TestRegistration()
        ////{
        ////    // Arrange
        ////    //var mockHandler = new Mock<HttpMessageHandler>();
        ////    //mockHandler.Protected()
        ////    //    .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
        ////    //    .ReturnsAsync(new HttpResponseMessage
        ////    //    {
        ////    //        StatusCode = HttpStatusCode.OK,
        ////    //        Content = new StringContent("{\"success\": true}")
        ////    //    });

        ////    //var client = new HttpClient(mockHandler.Object);

        ////    // Act & Assert
        ////    //await Assert.ThrowsExceptionAsync<Exception>(async () =>
        ////    //{
        ////    //    CulinaryRecipesApp.APIClient.PostRequest("api/main/registeruser", new UserBM
        ////    //    {
        ////    //        Nickname = "nickname",
        ////    //        Login = "test@gmail.com",
        ////    //        Password = "12345!",
        ////    //        Recipes = new Dictionary<int, string>(),
        ////    //        Selections = new Dictionary<int, string>(),
        ////    //        CommentGrades = new Dictionary<int, string>(),
        ////    //        SubscriptionFollowers = new Dictionary<int, string>(),
        ////    //        SubscriptionFollowings = new Dictionary<int, string>()
        ////    //    });
        ////    //});
        ////    try
        ////    {
        ////        CulinaryRecipesApp.APIClient.PostRequest("api/main/registeruser", new UserBM
        ////        {
        ////            Nickname = "nickname",
        ////            Login = "test@gmail.com",
        ////            Password = "12345!",
        ////            Recipes = new Dictionary<int, string>(),
        ////            Selections = new Dictionary<int, string>(),
        ////            CommentGrades = new Dictionary<int, string>(),
        ////            SubscriptionFollowers = new Dictionary<int, string>(),
        ////            SubscriptionFollowings = new Dictionary<int, string>()
        ////        });
        ////        // Если мы дошли до этой точки, тест считается успешным
        ////        Assert.IsTrue(true, "Тест успешно выполнен");
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        // Если произошло исключение, отмечаем тест как неудачный
        ////        Assert.Fail($"Тест завершился с ошибкой: {ex.Message}");
        ////    }
        ////}

        




        //[TestMethod]
        //public void LoginUser_ValidCredentials_ShouldReturnUser()
        //{
        //    // Arrange
        //    var login = "test@gmail.com";
        //    var password = "12345!";
        //    var user = new UserVM()
        //    {
        //        Nickname = "nickname",
        //        Login = login,
        //        Password = password,
        //        Id = 1,
        //        AvatarName = "noimage",
        //        AvatarPath = "noimage",
        //        Recipes = new Dictionary<int, string>(),
        //        Selections = new Dictionary<int, string>(),
        //        CommentGrades = new Dictionary<int, string>(),
        //    };

            
        //    mockUserLogic.Setup(x => x.Read(new UserBM
        //    {
        //        Login = login,
        //        Password = password
        //    })).Returns(new List<UserVM>() { user });

        //    // Act
        //    //var controller = new MainController(mockUserLogic.Object);
        //    var result = controller.LoginUser(login, password);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(user.Id, result.Id);
        //    Assert.AreEqual(user.Nickname, result.Nickname);
        //}


        


        



        //[TestMethod]
        //public void TestLogin()
        //{
        //    // Arrange
        //    // Регистрация пользователя
        //    string login = "pochta1@gmail.com";
        //    string password = "12345!";
        //    //var user = new UserBM
        //    //{
        //    //    Nickname = "nickname",
        //    //    Login = login,
        //    //    Password = password,
        //    //    Recipes = new Dictionary<int, string>(),
        //    //    Selections = new Dictionary<int, string>(),
        //    //    CommentGrades = new Dictionary<int, string>(),
        //    //    SubscriptionFollowers = new Dictionary<int, string>(),
        //    //    SubscriptionFollowings = new Dictionary<int, string>()
        //    //};
        //    //CulinaryRecipesApp.APIClient.PostRequest("api/main/registeruser", user);
        //    CulinaryRecipesApp.APIClient.PostRequest("api/main/registeruser", new UserBM
        //    {
        //        Nickname = "nickname",
        //        Login = "test@gmail.com",
        //        Password = "12345!",
        //        Recipes = new Dictionary<int, string>(),
        //        Selections = new Dictionary<int, string>(),
        //        CommentGrades = new Dictionary<int, string>(),
        //        SubscriptionFollowers = new Dictionary<int, string>(),
        //        SubscriptionFollowings = new Dictionary<int, string>()
        //    });




        //    // Act
        //    var result = CulinaryRecipesApp.APIClient.GetRequest<UserVM>($"api/main/loginuser?login={login}&password={password}");

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("nickname", result.Nickname);
        //    Assert.AreEqual(login, result.Login);
        //}


        //[TestMethod]
        //public void TestRegistration()
        //{
        //    // Arrange
        //    var mockHandler = new Mock<HttpMessageHandler>();
        //    mockHandler.Protected()
        //        .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
        //        .ReturnsAsync(new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.OK,
        //            Content = new StringContent("{\"success\": true}")
        //        });

        //    var client = new HttpClient(mockHandler.Object);

        //    try
        //    {
        //        CulinaryRecipesApp.APIClient.PostRequest("api/main/registeruser", new UserBM
        //        {
        //            Nickname = "nickname",
        //            Login = "test@gmail.com",
        //            Password = "12345!",
        //            AvatarName = "noimage",
        //            AvatarPath = "noimage",
        //            Recipes = new Dictionary<int, string>(),
        //            Selections = new Dictionary<int, string>(),
        //            CommentGrades = new Dictionary<int, string>(),
        //            SubscriptionFollowers = new Dictionary<int, string>(),
        //            SubscriptionFollowings = new Dictionary<int, string>()
        //        });
        //        // Если мы дошли до этой точки, тест считается успешным
        //        Assert.IsTrue(true, "Тест успешно выполнен");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Если произошло исключение, отмечаем тест как неудачный
        //        Assert.Fail($"Тест завершился с ошибкой: {ex.Message}");
        //    }
        //}





















        //WORK
        
        [TestMethod]
        public void RegisterUser_()
        {
            // Arrange
            var user = new UserBM
            {
                Nickname = "nickname",
                Login = "test@gmail.com",
                Password = "12345!",
                Recipes = new Dictionary<int, string>(),
                Selections = new Dictionary<int, string>(),
                CommentGrades = new Dictionary<int, string>(),
                SubscriptionFollowers = new Dictionary<int, string>(),
                SubscriptionFollowings = new Dictionary<int, string>()
            };

            // Act
            controller.RegisterUser(user);

            // Assert
            mockUserLogic.Verify(x => x.CreateOrUpdate(It.IsAny<UserBM>()), Times.Once);
        }

        [TestMethod]
        public void LoginUser_()
        {
            // Arrange
            var expectedUser = new UserVM
            {
                Nickname = "nickname",
                Login = "test@gmail.com",
                Password = "12345!",
                AvatarName = "noimage",
                AvatarPath = "noimage",
                Recipes = new Dictionary<int, string>(),
                Selections = new Dictionary<int, string>(),
                CommentGrades = new Dictionary<int, string>(),
            };

            var userList = new List<UserVM>();
            userList.Add(expectedUser);

            mockUserLogic.Setup(ul => ul.Read(It.IsAny<UserBM>()))
                         .Returns(userList);

            // Act
            var result = controller.LoginUser("test@gmail.com", "12345!");

            // Assert
            Assert.IsInstanceOfType(result, typeof(UserVM));
            Assert.AreEqual(expectedUser.Nickname, result.Nickname);
            mockUserLogic.Verify(ul => ul.Read(It.IsAny<UserBM>()), Times.Once);
        }

        [TestMethod]
        public void UpdateUser_()
        {
            // Arrange
            mockUserLogic.Setup(ul => ul.CreateOrUpdate(It.IsAny<UserBM>()));

            var user = new UserBM
            {
                Id = 1,
                Nickname = "Olga",
                Login = "test@gmail.com",
                Password = "12345!",
                AvatarName = "noimage",
                AvatarPath = "noimage",
                Recipes = new Dictionary<int, string>(),
                Selections = new Dictionary<int, string>(),
                CommentGrades = new Dictionary<int, string>(),
            };

            // Act
            controller.UpdateUser(user);

            // Assert
            mockUserLogic.Verify(ul => ul.CreateOrUpdate(It.IsAny<UserBM>()), Times.Once);
        }

        [TestMethod]
        public void GetUserList_()
        {
            // Arrange
            var expectedUsers = new List<UserVM>
            {
                new UserVM { Nickname = "User1", Login = "user1@mail.com", Password = "pass1", AvatarName = "noimage", AvatarPath = "noimage", 
                    Recipes = new Dictionary<int, string>(), Selections = new Dictionary<int, string>(), CommentGrades = new Dictionary<int, string>()},
                new UserVM { Nickname = "User2", Login = "user2@mail.com", Password = "pass2", AvatarName = "noimage", AvatarPath = "noimage", 
                    Recipes = new Dictionary<int, string>(), Selections = new Dictionary<int, string>(), CommentGrades = new Dictionary<int, string>()},
            };

            mockUserLogic.Setup(ul => ul.Read(null)).Returns(expectedUsers);

            // Act
            var result = controller.GetUserList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<UserVM>));

            var resultList = result as List<UserVM>;
            Assert.AreEqual(expectedUsers.Count, resultList.Count);

            // Проверка, что каждый ожидаемый пользователь присутствует в результирующем списке
            foreach (var expectedUser in expectedUsers)
            {
                var matchingUser = resultList.FirstOrDefault(u =>
                    u.Nickname == expectedUser.Nickname &&
                    u.Login == expectedUser.Login &&
                    u.Password == expectedUser.Password);

                Assert.IsNotNull(matchingUser, $"Expected user {expectedUser.Nickname} not found in the result.");
            }

            mockUserLogic.Verify(ul => ul.Read(null), Times.Once);
        }

        [TestMethod]
        public void GetRecipeList_()
        {
            // Arrange
            var expectedRecipes = new List<RecipeVM>
            {
                new RecipeVM { Name = "Рецепт1", Description = "Описание1", ImageName = "noimage", ImagePath = "noimage", Timing = DateTime.Now, PortionAmount = 1, 
                    CategoryId = 1, UserId = 1, CommentGrades = new Dictionary<int, string>(), StepCookings = new Dictionary<int, string>(), RecipeIngredients = new Dictionary<int, string>()},
                new RecipeVM { Name = "Рецепт2", Description = "Описание2", ImageName = "noimage", ImagePath = "noimage", Timing = DateTime.Now, PortionAmount = 2,
                    CategoryId = 2, UserId = 2, CommentGrades = new Dictionary<int, string>(), StepCookings = new Dictionary<int, string>(), RecipeIngredients = new Dictionary<int, string>()}
            };

            mockRecipeLogic.Setup(ul => ul.Read(null)).Returns(expectedRecipes);

            // Act
            var result = controller.GetRecipeList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<RecipeVM>));

            var resultList = result as List<RecipeVM>;
            Assert.AreEqual(expectedRecipes.Count, resultList.Count);

            foreach (var expectedRecipe in expectedRecipes)
            {
                var matchingRecipe = resultList.FirstOrDefault(u =>
                    u.Name == expectedRecipe.Name &&
                    u.Description == expectedRecipe.Description &&
                    u.UserId == expectedRecipe.UserId);

                Assert.IsNotNull(matchingRecipe, $"Expected recipe {expectedRecipe.Name} not found in the result.");
            }

            mockRecipeLogic.Verify(ul => ul.Read(null), Times.Once);
        }

        [TestMethod]
        public void GetRecipe_()
        {
            // Arrange
            var recipeId = 1;
            var expectedRecipe = new RecipeVM
            {
                Id = recipeId,
                Name = "Рецепт1",
                Description = "Описание1",
                ImageName = "noimage",
                ImagePath = "noimage",
                Timing = DateTime.Now,
                PortionAmount = 1,
                CategoryId = 1,
                UserId = 1,
                CommentGrades = new Dictionary<int, string>(),
                StepCookings = new Dictionary<int, string>(),
                RecipeIngredients = new Dictionary<int, string>()
            };

            var recipeList = new List<RecipeVM> { expectedRecipe };

            mockRecipeLogic.Setup(rl => rl.Read(It.IsAny<RecipeBM>()))
                           .Returns(recipeList);

            // Act
            var result = controller.GetRecipe(recipeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RecipeVM));

            Assert.AreEqual(expectedRecipe.Id, result.Id);
            Assert.AreEqual(expectedRecipe.Name, result.Name);

            mockRecipeLogic.Verify(rl => rl.Read(It.IsAny<RecipeBM>()), Times.Once);
        }

        [TestMethod]
        public void CreateRecipe_()
        {
            // Arrange
            var recipe = new RecipeBM
            {
                Name = "Рецепт1",
                Description = "Описание1",
                ImageName = "noimage",
                ImagePath = "noimage",
                Timing = DateTime.Now,
                PortionAmount = 1,
                CategoryId = 1,
                UserId = 1,
                CommentGrades = new Dictionary<int, string>(),
                StepCookings = new Dictionary<int, string>(),
                RecipeIngredients = new Dictionary<int, string>()
            };

            // Act
            controller.CreateOrUpdateRecipe(recipe);

            // Assert
            mockRecipeLogic.Verify(x => x.CreateOrUpdate(It.IsAny<RecipeBM>()), Times.Once);
        }

        [TestMethod]
        public void DeleteRecipe_()
        {
            // Arrange
            var recipe = new RecipeBM
            {
                Id = 1,
                Name = "Рецепт1",
                Description = "Описание1",
                ImageName = "noimage",
                ImagePath = "noimage",
                Timing = DateTime.Now,
                PortionAmount = 1,
                CategoryId = 1,
                UserId = 1,
                CommentGrades = new Dictionary<int, string>(),
                StepCookings = new Dictionary<int, string>(),
                RecipeIngredients = new Dictionary<int, string>()
            };

            // Act
            controller.DeleteRecipe(recipe);

            // Assert
            mockRecipeLogic.Verify(rl => rl.Delete(It.Is<RecipeBM>(r =>
                r.Name == recipe.Name && 
                r.Description == recipe.Description)), Times.Once);
        }


    }
}