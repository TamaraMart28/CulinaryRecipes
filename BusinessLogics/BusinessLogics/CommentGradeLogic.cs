using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using BusinessLogics.StoragesContracts;
using BusinessLogics.BusinessLogicsContracts;

namespace BusinessLogics.BusinessLogics
{
    public class CommentGradeLogic : ICommentGradeLogic
    {
        private readonly ICommentGradeStorage _cgStorage;

        public CommentGradeLogic(ICommentGradeStorage cgStorage)
        {
            _cgStorage = cgStorage;
        }

        public List<CommentGradeVM> Read(CommentGradeBM model)
        {
            if (model == null)
            {
                return _cgStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CommentGradeVM> { _cgStorage.GetElement(model) };
            }
            return _cgStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CommentGradeBM model)
        {
            var element = _cgStorage.GetElement(new CommentGradeBM
            {
                Comment = model.Comment,
                Grade = model.Grade,
                UserId = model.UserId,
                RecipeId = model.RecipeId
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая запись");
            }
            if (model.Id.HasValue)
            {
                _cgStorage.Update(model);
            }
            else
            {
                _cgStorage.Insert(model);
            }
        }

        public void Delete(CommentGradeBM model)
        {
            var element = _cgStorage.GetElement(new CommentGradeBM { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _cgStorage.Delete(model);
        }
    }
}
