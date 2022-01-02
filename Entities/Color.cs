using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Color
    {
        public decimal ColorId { get; set; }
        public string ColorName { get; set; }

        // Color המרת אוביקט  
        //Model.Colors לאוביקט 
        public static Model.Color ColorToColors(Color color)
        {
            return new Model.Color()
            {
                ColorId = color.ColorId,
                ColorName = color.ColorName
            };
        }

        // Model.Colors המרת אוביקט  
        //Color לאוביקט 
        public static Color ColorsToColor(Model.Color color)
        {
            return new Color()
            {
                ColorId = color.ColorId,
                ColorName = color.ColorName
            };
        }

        // Model.Color המרת רשימת  
        //Color לרשימת 
        public static List<Color> ListColorsToListColor(List<Model.Color> colors)
        {
            List<Color> colorsList = new List<Color>();
            foreach (Model.Color item in colors)
            {
                Color i = ColorsToColor(item);
                colorsList.Add(i);
            }
            return colorsList;
        }
    }
}