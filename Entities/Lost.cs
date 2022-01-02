using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
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
        public double LostLat { get; set; }
        public double LostLng { get; set; }
        public decimal SearchRadius { get; set; }
        public string LostImage { get; set; }
        public decimal UserId { get; set; }
        public  Nullable<decimal> Color1 { get; set; }
        public  Nullable<decimal> Color2 { get; set; }
        public Nullable<decimal> Color3 { get; set; }
        public string LostAddress { get; set; }
        public bool LostStatus { get; set; }


       // lost המרת אוביקט
       //Model.losts לאוביקט
        public static Model.Lost LostToLosts(Lost lost)
        {
            return new Model.Lost()
            {
                CategoryId=lost.CategoryId,
                ItemId=lost.ItemId,
                ItemName=lost.ItemName,
                LostDate=lost.LostDate,
                LostDescription=lost.LostDescription,
                LostId=lost.LostId,
                LostImage=lost.LostImage,
                LostLat=lost.LostLat,
                LostLng= lost.LostLng,
                MaterialId=lost.MaterialId,
                SearchRadius=lost.SearchRadius,
                UserId=lost.UserId,
                color1=lost.Color1,
                color2=lost.Color2,
                color3=lost.Color3,
                LostStatus=lost.LostStatus,
                LostAddress =lost.LostAddress
            };
        }

        // lost המרת רשימת  
        //Model.losts לרשימת 
        public static List<Model.Lost> ListLostToListLosts(List<Lost> losts)
        {
            List<Model.Lost> listLosts = new List<Model.Lost>();
            foreach (Lost item in losts)
            {
                Model.Lost l = LostToLosts(item);
                listLosts.Add(l);
            }
            return listLosts;
        }


        // Model.losts המרת אוביקט  
        //lost לאוביקט 
        public static Lost LostsToLost(Model.Lost lost)
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
                LostLat = Convert.ToDouble(lost.LostLat),
                LostLng = Convert.ToDouble(lost.LostLng),
                MaterialId = lost.MaterialId,
                SearchRadius = lost.SearchRadius,
                UserId = lost.UserId,
                Color1 = lost.color1,
                Color2 = lost.color2,
                Color3 = lost.color3,
                LostAddress=lost.LostAddress,
                LostStatus=lost.LostStatus==true

            };
        }

        // Model.losts המרת רשימת  
        //lost לרשימת 
        public static List<Lost> ListLostsToListLost(List<Model.Lost> losts)
        {
            List<Lost> listLosts = new List<Lost>();
            foreach (Model.Lost item in losts)
            {
                Lost l = LostsToLost(item);
                listLosts.Add(l);
            }
            return listLosts;
        }

    }
}