using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.BusinessLogicsContracts
{
    public interface ICommentGradeLogic
    {
        List<CommentGradeVM> Read(CommentGradeBM model);
        void CreateOrUpdate(CommentGradeBM model);
        void Delete(CommentGradeBM model);
    }
}
