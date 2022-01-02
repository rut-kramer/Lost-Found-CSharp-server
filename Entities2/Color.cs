using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurProject.Models
{
    public class Color
    {
        public decimal ColorId { get; set; }
        public string ColorName { get; set; }

        // Color המרת אוביקט  
        //Model.Colors לאוביקט 
        public static Model.Colors ColorToColors(Color color)
        {
            return new Model.Colors()
            {
                ColorId = color.ColorId,
                ColorName = color.ColorName
            };
        }

        // Model.Colors המרת אוביקט  
        //Color לאוביקט 
        public static Color ColorsToColor(Model.Colors color)
        {
            return new Color()
            {
                ColorId = color.ColorId,
                ColorName = color.ColorName
            };
        }
    }
}