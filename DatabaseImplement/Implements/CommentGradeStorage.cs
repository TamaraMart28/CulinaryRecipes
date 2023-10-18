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
    public class CommentGradeStorage : ICommentGradeStorage
    {
        public List<CommentGradeVM> GetFullList()
        {
            using var context = new CulinaryRecipesDatabase();

            return context.CommentGrades
               .Select(rec => new CommentGradeVM
               {
                   Id = rec.Id,
                   Comment = rec.Comment,
                   Grade = rec.Grade,
                   UserId = rec.UserId,
                   RecipeId = rec.RecipeId
               })
                .ToList();
        }

        public List<CommentGradeVM> GetFilteredList(CommentGradeBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            return context.CommentGrades.Where(rec => rec.RecipeId == model.RecipeId)
            .Select(rec => new CommentGradeVM
            {
                Id = rec.Id,
                Comment = rec.Comment,
                Grade = rec.Grade,
                UserId = rec.UserId,
                RecipeId = rec.RecipeId
            })
            .ToList();
        }


        public CommentGradeVM GetElement(CommentGradeBM model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new CulinaryRecipesDatabase();

            var _el = context.CommentGrades.FirstOrDefault(rec => rec.Id == model.Id || rec.RecipeId == model.RecipeId);
            return _el != null ? new CommentGradeVM
            {
                Id = _el.Id,
                Comment = _el.Comment,
                Grade = _el.Grade,
                UserId = _el.UserId,
                RecipeId = _el.RecipeId
            } :
            null;
        }

        public void Insert(CommentGradeBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            context.CommentGrades.Add(CreateModel(model, new CommentGrade()));
            context.SaveChanges();
        }

        public void Update(CommentGradeBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.CommentGrades.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(CommentGradeBM model)
        {
            using var context = new CulinaryRecipesDatabase();

            var element = context.CommentGrades.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.CommentGrades.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private CommentGrade CreateModel(CommentGradeBM model, CommentGrade _el)
        {
            _el.Comment = model.Comment;
            _el.Grade = model.Grade;
            _el.UserId = model.UserId;
            _el.RecipeId = model.RecipeId;
            return _el;
        }
    }
}
