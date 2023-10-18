﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
    public class RecipeIngredient
    {
        public int? Id { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public string Amount { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
