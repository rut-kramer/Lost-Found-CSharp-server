using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Item
    {
        public decimal ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> CategoryId { get; set; }

        // Item המרת אוביקט  
        //Model.Items לאוביקט 
        public static Model.Item ItemToItems(Item item)
        {
            return new Model.Item()
            {
                CategoryId = item.CategoryId,
                ItemId=item.ItemId,
                ItemName=item.ItemName
            };
        }

        // Item המרת רשימת  
        //Model.Items לרשימת 
        public static List<Model.Item> ListItemToListItems(List<Item> items)
        {
            List<Model.Item> itemsList = new List<Model.Item>();
            foreach (Item item in items)
            {
                Model.Item i = ItemToItems(item);
                itemsList.Add(i);
            }
            return itemsList;
        }


        // Model.Items המרת אוביקט  
        //Item לאוביקט 
        public static Item ItemsToItem(Model.Item item)
        {
            return new Item()
            {
                CategoryId = item.CategoryId,
                ItemId = item.ItemId,
                ItemName = item.ItemName
            };
        }

        // Model.Items המרת רשימת  
        //Item לרשימת 
        public static List<Item> ListItemsToListItem(List<Model.Item> items)
        {
            List<Item> itemsList = new List<Item>();
            foreach (Model.Item item in items)
            {
                Item i = ItemsToItem(item);
                itemsList.Add(i);
            }
            return itemsList;
        }
    }
}