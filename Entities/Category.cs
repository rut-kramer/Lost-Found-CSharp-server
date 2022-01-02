using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Category
    {
        public decimal CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Category המרת אוביקט  
        //Model.Categories לאוביקט 
        public static Model.Category CategoryToCategories(Category category)
        {
            return new Model.Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }


        // Category המרת רשימת  
        //Model.Categories לרשימת 
        public static List<Model.Category> ListCategoryToListCategories(List<Category> categories)
        {
            List<Model.Category> c = new List<Model.Category>();
            foreach (Category item in categories)
            {
                Model.Category category = CategoryToCategories(item);
                c.Add(category);
            }
            return c;
        }
        
        // Model.Categories המרת אוביקט  
        //Category לאוביקט 
        public static Category CategoriesToCategory(Model.Category category)
        {
            return new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        // Model.Categories המרת רשימת  
        //Category לרשימת 
        public static List<Category> ListCategoriesToListCategory(List<Model.Category> categories)
        {
            List<Category> c = new List<Category>();
            foreach (Model.Category item in categories)
            {
                Category category = CategoriesToCategory(item);
                c.Add(category);
            }
            return c;
        }

    }
}