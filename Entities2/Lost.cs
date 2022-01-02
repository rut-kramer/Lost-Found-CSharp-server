using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurProject.Models
{
    public class Lost
    {
        public decimal LostId { get; set; }
        public decimal CategoryId { get; set; }
        public decimal ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> MaterialId { get; set; }
        public string LostDescription { get; set; }
        public System.DateTime LostDate { get; set; }
        public decimal LostLocation { get; set; }
        public decimal SearchRadius { get; set; }
        public string LostImage { get; set; }
        public decimal UserId { get; set; }

        // lost המרת אוביקט  
        //Model.losts לאוביקט 
        public static Model.Losts LostToLosts(Lost lost)
        {
            return new Model.Losts()
            {
                CategoryId=lost.CategoryId,
                ItemId=lost.ItemId,
                ItemName=lost.ItemName,
                LostDate=lost.LostDate,
                LostDescription=lost.LostDescription,
                LostId=lost.LostId,
                LostImage=lost.LostImage,
                LostLocation=lost.LostLocation,
                MaterialId=lost.MaterialId,
                SearchRadius=lost.SearchRadius,
                UserId=lost.UserId
            };
        }

        // Model.losts המרת אוביקט  
        //lost לאוביקט 
        public static Lost LostToColors(Model.Losts lost)
        {
            return new Lost()
            {
                CategoryId = lost.CategoryId,
                ItemId = lost.ItemId,
                ItemName = lost.ItemName,
                LostDate = lost.LostDate,
                LostDescription = lost.LostDescription,
                LostId = lost.LostId,
                LostImage = lost.LostImage,
                LostLocation = lost.LostLocation,
                MaterialId = lost.MaterialId,
                SearchRadius = lost.SearchRadius,
                UserId = lost.UserId
            };
        }

    }
}