using BusinessLogics.BusinessLogics;
using BusinessLogics.BusinessLogicsContracts;
using BusinessLogics.StoragesContracts;
using DatabaseImplement.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
//storage
builder.Services.AddTransient<IUserStorage, UserStorage>();
builder.Services.AddTransient<ISubscriptionStorage, SubscriptionStorage>();
builder.Services.AddTransient<ICommentGradeStorage, CommentGradeStorage>();
builder.Services.AddTransient<IRecipeStorage, RecipeStorage>();
builder.Services.AddTransient<IIngredientStorage, IngredientStorage>();
builder.Services.AddTransient<IStepCookingStorage, StepCookingStorage>();
builder.Services.AddTransient<ISelectionStorage, SelectionStorage>();
builder.Services.AddTransient<ICategoryStorage, CategoryStorage>();
builder.Services.AddTransient<ISelectionRecipeStorage, SelectionRecipeStorage>();
builder.Services.AddTransient<IRecipeIngredientStorage, RecipeIngredientStorage>();

//logic
builder.Services.AddTransient<IUserLogic, UserLogic>();
builder.Services.AddTransient<ISubscriptionLogic, SubscriptionLogic>();
builder.Services.AddTransient<ICommentGradeLogic, CommentGradeLogic>();
builder.Services.AddTransient<IRecipeLogic, RecipeLogic>();
builder.Services.AddTransient<IIngredientLogic, IngredientLogic>();
builder.Services.AddTransient<IStepCookingLogic, StepCookingLogic>();
builder.Services.AddTransient<ISelectionLogic, SelectionLogic>();
builder.Services.AddTransient<ICategoryLogic, CategoryLogic>();
builder.Services.AddTransient<ISelectionRecipeLogic, SelectionRecipeLogic>();
builder.Services.AddTransient<IRecipeIngredientLogic, RecipeIngredientLogic>();
//


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
