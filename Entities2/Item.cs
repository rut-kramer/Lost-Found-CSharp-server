using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurProject.Models
{
    public class Item
    {
        public decimal ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> CategoryId { get; set; }

        // Item המרת אוביקט  
        //Model.Items לאוביקט 
        public static Model.Items ItemToItems(Item item)
        {
            return new Model.Items()
            {
                CategoryId = item.CategoryId,
                ItemId=item.ItemId,
                ItemName=item.ItemName
            };
        }

        // Model.Items המרת אוביקט  
        //Item לאוביקט 
        public static Item ItemsToItem(Model.Items item)
        {
            return new Item()
            {
                CategoryId = item.CategoryId,
                ItemId = item.ItemId,
                ItemName = item.ItemName
            };
        }
    }
}