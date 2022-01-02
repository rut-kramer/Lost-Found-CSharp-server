using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
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
        public double FoundLat { get; set; }
        public double FoundLng { get; set; }
        public string FoundImage { get; set; }
        public decimal UserId { get; set; }
        public Nullable<decimal> Color1 { get; set; }
        public Nullable<decimal> Color2 { get; set; }
        public Nullable<decimal> Color3 { get; set; }
        public string FoundAddress { get; set; }
        public bool FoundStatus { get; set; }

        // Found המרת אוביקט  
        //Model.Founds לאוביקט 
        public static Model.Found FoundToFounds(Found found)
        {
            return new Model.Found()
            {
                CategoryId = found.CategoryId,
                FoundDate = found.FoundDate,
                FoundDescription = found.FoundDescription,
                FoundId = found.FoundId,
                FoundImage = found.FoundImage,
                FoundLat = found.FoundLat,
                FoundLng = found.FoundLng,
                FoundName = found.FoundName,
                ItemId = found.ItemId,
                ItemName = found.ItemName,
                MaterialId = found.MaterialId,
                UserId = found.UserId,
                color1 = found.Color1,
                color2 = found.Color2,
                color3 = found.Color3,
                FoundStatus = found.FoundStatus,
                FoundAddress = found.FoundAddress

            };
        }

        // Found המרת רשימת  
        //Model.Founds לרשימת 
        public static List<Model.Found> ListFoundToFounds(List<Found> founds)
        {
            List<Model.Found> ListFounds = new List<Model.Found>();
            foreach (Found item in founds)
            {
                ListFounds.Add(Found.FoundToFounds(item));
            }
            return ListFounds;
        }

        // Model.Founds המרת אוביקט  
        //Found לאוביקט 
        public static Found FoundsToFound(Model.Found found)
        {
            return new Found()
            {
                CategoryId = found.CategoryId,
                FoundDate = found.FoundDate,
                FoundDescription = found.FoundDescription,
                FoundId = found.FoundId,
                FoundImage = found.FoundImage,
                FoundLat = Convert.ToDouble(found.FoundLat),
                FoundLng = Convert.ToDouble(found.FoundLng),
                FoundName = found.FoundName,
                ItemId = found.ItemId,
                ItemName = found.ItemName,
                MaterialId = found.MaterialId,
                UserId = found.UserId,
                Color1 = found.color1,
                Color2 = found.color2,
                Color3 = found.color3,
                FoundStatus = found.FoundStatus==true,
                FoundAddress = found.FoundAddress

            };
        }

        // Model.Founds המרת רשימת  
        //Found לרשימת 
        public static List<Found> ListFoundsToFound(List<Model.Found> founds)
        {
            List<Found> ListFounds = new List<Found>();
            foreach (Model.Found item in founds)
            {
                ListFounds.Add(Found.FoundsToFound(item));
            }
            return ListFounds;
        }
    }
}