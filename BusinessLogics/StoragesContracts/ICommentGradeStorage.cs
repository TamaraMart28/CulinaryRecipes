using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface ICommentGradeStorage
    {
        List<CommentGradeVM> GetFullList();
        List<CommentGradeVM> GetFilteredList(CommentGradeBM model);
        CommentGradeVM GetElement(CommentGradeBM model);
        void Insert(CommentGradeBM model);
        void Update(CommentGradeBM model);
        void Delete(CommentGradeBM model);
    }
}
