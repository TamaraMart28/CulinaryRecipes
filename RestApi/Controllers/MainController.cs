﻿using Microsoft.AspNetCore.Http;
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
        private readonly IRecipeLogic _recipeLogic;
        private readonly ICategoryLogic _categoryLogic;
        private readonly IRecipeIngredientLogic _riLogic;
        private readonly IStepCookingLogic _scLogic;
        private readonly IIngredientLogic _ingrLogic;
        private readonly ICommentGradeLogic _cgLogic;
        private readonly ISelectionLogic _selectionLogic;
        private readonly ISelectionRecipeLogic _srLogic;
        private readonly ISubscriptionLogic _subLogic;

        public MainController(IUserLogic userLogic, IRecipeLogic recipeLogic, ICategoryLogic categoryLogic,
            IRecipeIngredientLogic riLogic, IStepCookingLogic scLogic, IIngredientLogic ingrLogic,
            ICommentGradeLogic cgLogic, ISelectionLogic selectionLogic, ISelectionRecipeLogic srLogic,
            ISubscriptionLogic subLogic)
        {
            _userLogic = userLogic;
            _recipeLogic = recipeLogic;
            _categoryLogic = categoryLogic;
            _riLogic = riLogic;
            _scLogic = scLogic;
            _ingrLogic = ingrLogic;
            _cgLogic = cgLogic;
            _selectionLogic = selectionLogic;
            _srLogic = srLogic;
            _subLogic = subLogic;
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

        //Пользователь по id
        [HttpGet]
        public UserVM GetUserById(int userId) => _userLogic.Read(new UserBM { Id = userId })?[0];



        //RECIPE
        //Список всех рецептов
        [HttpGet]
        public List<RecipeVM> GetRecipeList() => _recipeLogic.Read(null)?.ToList();

        //Список личных рецептов
        [HttpGet]
        public List<RecipeVM> GetUsersRecipeList(int userId) => _recipeLogic.Read(new RecipeBM { Name = "", UserId = userId });

        //Список рецептов по категории
        [HttpGet]
        public List<RecipeVM> GetRecipeByCategoryList(int categoryId) => _recipeLogic.Read(new RecipeBM { CategoryId = categoryId });

        //Рецепт
        [HttpGet]
        public RecipeVM GetRecipe(int recipeId) => _recipeLogic.Read(new RecipeBM { Id = recipeId })?[0];

        //Рецепт по названию и пользователю
        [HttpGet]
        public RecipeVM GetRecipeByName(string name, int userId) => _recipeLogic.Read(new RecipeBM {  Name = name , UserId = userId})?[0];

        //Создание рецепта
        [HttpPost]
        public void CreateOrUpdateRecipe(RecipeBM model) => _recipeLogic.CreateOrUpdate(model);

        //Удаление рецепта
        [HttpPost]
        public void DeleteRecipe(RecipeBM model) => _recipeLogic.Delete(model);


        //CATEGORY
        //Список всех категорий
        [HttpGet]
        public List<CategoryVM> GetCategoryList() => _categoryLogic.Read(null)?.ToList();

        //Категория по описанию
        [HttpGet]
        public CategoryVM GetCategory(string description) => _categoryLogic.Read(new CategoryBM { Description = description })?[0];

        //Категория по id
        [HttpGet]
        public CategoryVM GetCategoryById(int categoryId) => _categoryLogic.Read(new CategoryBM { Id = categoryId })?[0];

        //Создание категории
        [HttpPost]
        public void CreateOrUpdateCategory(CategoryBM model) => _categoryLogic.CreateOrUpdate(model);

        //Удаление категории
        [HttpPost]
        public void DeleteCategory(CategoryBM model) => _categoryLogic.Delete(model);


        //INGREDIENT
        //Список всех ингредиентов
        [HttpGet]
        public List<IngredientVM> GetIngredientList() => _ingrLogic.Read(null)?.ToList();

        //Ингредиент по названию
        [HttpGet]
        public IngredientVM GetIngredient(string name)
        {
            var list = _ingrLogic.Read(new IngredientBM 
            { Name = name });
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        //Ингредиент по id
        [HttpGet]
        public IngredientVM GetIngredientById(int ingridientId) => _ingrLogic.Read(new IngredientBM { Id = ingridientId })?[0];

        //Создание ингредиента
        [HttpPost]
        public void CreateOrUpdateIngredient(IngredientBM model) => _ingrLogic.CreateOrUpdate(model);

        //Удаление ингредиента
        [HttpPost]
        public void DeleteIngredient(IngredientBM model) => _ingrLogic.Delete(model);



        //rECIPEiNGREDIENT
        //Создание
        [HttpPost]
        public void CreateOrUpdateRecipeIngredient(RecipeIngredientBM model) => _riLogic.CreateOrUpdate(model);

        //Список всех
        [HttpGet]
        public List<RecipeIngredientVM> GetRecipeIngredientList() => _riLogic.Read(null)?.ToList();

        //Список по рецепту
        [HttpGet]
        public List<RecipeIngredientVM> GetRecipeIngredientByRecipeList(int recipeId) => _riLogic.Read(new RecipeIngredientBM { RecipeId = recipeId });

        //Удаление
        [HttpPost]
        public void DeleteRecipeIngredient(RecipeIngredientBM model) => _riLogic.Delete(model);


        //STEPCOOKING
        //Создание шага приготовления
        [HttpPost]
        public void CreateOrUpdateStepCooking(StepCookingBM model) => _scLogic.CreateOrUpdate(model);

        //Список всех
        [HttpGet]
        public List<StepCookingVM> GetStepCookingList() => _scLogic.Read(null)?.ToList();

        //Шаг по названию
        [HttpGet]
        public StepCookingVM GetStepCookingByName(int scId) => _scLogic.Read(new StepCookingBM { Id = scId })?[0];

        //Список по рецепту
        [HttpGet]
        public List<StepCookingVM> GetStepCookingByRecipeList(int recipeId) => _scLogic.Read(new StepCookingBM { RecipeId = recipeId });

        //Удаление
        [HttpPost]
        public void DeleteStepCooking(StepCookingBM model) => _scLogic.Delete(model);



        //cOMMENTgRADE
        //Список всех
        [HttpGet]
        public List<CommentGradeVM> GetCommentGradeList() => _cgLogic.Read(null)?.ToList();

        //Создание 
        [HttpPost]
        public void CreateOrUpdateCommentGrade(CommentGradeBM model) => _cgLogic.CreateOrUpdate(model);

        //Удаление 
        [HttpPost]
        public void DeleteCommentGrade(CommentGradeBM model) => _cgLogic.Delete(model);

        //Список по рецепту
        [HttpGet]
        public List<CommentGradeVM> GetCommentGradeByRecipeList(int recipeId) => _cgLogic.Read(new CommentGradeBM { RecipeId = recipeId });


        //SELECTION
        //Список всех подборок
        [HttpGet]
        public List<SelectionVM> GetSelectionList() => _selectionLogic.Read(null)?.ToList();

        //Список личных рецептов
        [HttpGet]
        public List<SelectionVM> GetUsersSelectionList(int userId) => _selectionLogic.Read(new SelectionBM { Name = "", UserId = userId });

        //Подборка
        [HttpGet]
        public SelectionVM GetSelection(int selectionId) => _selectionLogic.Read(new SelectionBM { Id = selectionId })?[0];

        //Подборка по названию и пользователю
        [HttpGet]
        public SelectionVM GetSelectionByName(string name, int userId) => _selectionLogic.Read(new SelectionBM { Name = name, UserId = userId })?[0];

        //Создание рецепта
        [HttpPost]
        public void CreateOrUpdateSelection(SelectionBM model) => _selectionLogic.CreateOrUpdate(model);

        //Удаление рецепта
        [HttpPost]
        public void DeleteSelection(SelectionBM model) => _selectionLogic.Delete(model);


        //sELECTIONrECIPE
        [HttpGet]
        public List<SelectionRecipeVM> GetSelectionRecipesList() => _srLogic.Read(null)?.ToList();

        [HttpGet]
        public SelectionRecipeVM GetSelectionRecipe(int srId) => _srLogic.Read(new SelectionRecipeBM { Id = srId })?[0];

        [HttpGet]
        public SelectionRecipeVM GetSelectionRecipeByIds(int recipeId, int selectionId) => _srLogic.ReadByIds(new SelectionRecipeBM { RecipeId = recipeId, SelectionId = selectionId })?[0];

        [HttpGet]
        public List<SelectionRecipeVM> GetSelectionRecipeBySelection(int selectionId) => _srLogic.Read(new SelectionRecipeBM { SelectionId = selectionId });

        [HttpPost]
        public void CreateOrUpdateSelectionRecipe(SelectionRecipeBM model) => _srLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteSelectionRecipe(SelectionRecipeBM model) => _srLogic.Delete(model);


        //SUBSCRIPTION
        [HttpGet]
        public List<SubscriptionVM> GetSubscriptionList() => _subLogic.Read(null)?.ToList();

        [HttpGet]
        public SubscriptionVM GetSubscription(int subId) => _subLogic.Read(new SubscriptionBM { Id = subId })?[0];

        [HttpGet]
        public SubscriptionVM GetSubscriptionByIds(int userIdFollower, int userIdFollowing) => _subLogic.ReadByIds(new SubscriptionBM { UserIdFollower = userIdFollower, UserIdFollowing = userIdFollowing })?[0];

        [HttpGet]
        public List<SubscriptionVM> GetSubscriptionByFollower(int userIdFollower) => _subLogic.Read(new SubscriptionBM { UserIdFollower = userIdFollower });

        [HttpGet]
        public List<SubscriptionVM> GetSubscriptionByFollowing(int userIdFollowing) => _subLogic.Read(new SubscriptionBM { UserIdFollowing = userIdFollowing });

        [HttpPost]
        public void CreateOrUpdateSubscription(SubscriptionBM model) => _subLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteSubscription(SubscriptionBM model) => _subLogic.Delete(model);
    }
}
