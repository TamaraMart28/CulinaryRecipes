using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplement
{
    public class CulinaryRecipesDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=CulinaryRecipesDatabase;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Subscription> Subscriptions { set; get; }
        public virtual DbSet<CommentGrade> CommentGrades { set; get; }
        public virtual DbSet<Recipe> Recipes { set; get; }
        public virtual DbSet<Ingredient> Ingredients { set; get; }
        public virtual DbSet<StepCooking> StepCookings { set; get; }
        public virtual DbSet<Selection> Selections { set; get; }
        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<SelectionRecipe> SelectionRecipes { set; get; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { set; get; }
    }
}
