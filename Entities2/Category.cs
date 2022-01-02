using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurProject.Models
{
    public class Category
    {
        public decimal CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Category המרת אוביקט  
        //Model.Categories לאוביקט 
        public static Model.Categories CategoryToCategories(Category category)
        {
            return new Model.Categories()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        // Model.Categories המרת אוביקט  
        //Category לאוביקט 
        public static Category CategoriesToCategory(Model.Categories category)
        {
            return new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
    }
}