using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace System.ComponentModel.DataAnnotations
{
    public class RequiredGreaterThanZero : ValidationAttribute
    {
        /// <summary>
        /// Designed for dropdowns to ensure that a selection is valid and not the dummy "SELECT" entry
        /// </summary>
        /// <param name="value">The integer value of the selection</param>
        /// <returns>True if value is greater than zero</returns>
        public override bool IsValid(object value)
        {
            // return true if value is a non-null number > 0, otherwise return false
            decimal i;
            return value != null && decimal.TryParse(value.ToString(), out i) && i > 0;
        }
    }

    public class ValidIngredientType : ValidationAttribute
    {
        public string Ingredient { get; set; }

        public override bool IsValid(object value)
        {
            if (Ingredient == "Yeast")
            {
                return false;
            }
            return true;
        }
    }

}