﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;

namespace BusinessLogics.StoragesContracts
{
    public interface IUserStorage
    {
        List<UserVM> GetFullList();
        List<UserVM> GetFilteredList(UserBM model);
        UserVM GetElement(UserBM model);
        void Insert(UserBM model);
        void Update(UserBM model);
        void Delete(UserBM model);
    }
}
