﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.BindingModels
{
    public class IngredientBM
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public Dictionary<int, string> RecipeIngredients { get; set; }
    }
}
