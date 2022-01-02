using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurProject.Models
{
    public class Found
    {
        public decimal FoundId { get; set; }
        public string FoundName { get; set; }
        public decimal CategoryId { get; set; }
        public decimal ItemId { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> MaterialId { get; set; }
        public string FoundDescription { get; set; }
        public System.DateTime FoundDate { get; set; }
        public decimal FoundLocation { get; set; }
        public string FoundImage { get; set; }
        public decimal UserId { get; set; }

        // Found המרת אוביקט  
        //Model.Founds לאוביקט 
        public static Model.Founds FoundToFounds(Found found)
        {
            return new Model.Founds()
            {
                CategoryId=found.CategoryId,
                FoundDate=found.FoundDate,
                FoundDescription=found.FoundDescription,
                FoundId=found.FoundId,
                FoundImage=found.FoundImage,
                FoundLocation=found.FoundLocation,
                FoundName=found.FoundName,
                ItemId=found.ItemId,
                ItemName=found.ItemName,
                MaterialId=found.MaterialId,
                UserId=found.UserId
            };
        }

        // Model.Founds המרת אוביקט  
        //Found לאוביקט 
        public static Found FoundsToFound(Model.Founds found)
        {
            return new Found()
            {
                CategoryId = found.CategoryId,
                FoundDate = found.FoundDate,
                FoundDescription = found.FoundDescription,
                FoundId = found.FoundId,
                FoundImage = found.FoundImage,
                FoundLocation = found.FoundLocation,
                FoundName = found.FoundName,
                ItemId = found.ItemId,
                ItemName = found.ItemName,
                MaterialId = found.MaterialId,
                UserId = found.UserId
            };
        }

    }
}