using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurProject.Models
{
    public class Material
    {
        public decimal MaterialId { get; set; }
        public string MaterialName { get; set; }
        //Material המרת אוביקט  
        // Model.Materials לאוביקט 
        public static Model.Materials MaterialToMaterials(Material material)
        {
            return new Model.Materials()
            {
                MaterialId = material.MaterialId,
                MaterialName = material.MaterialName,
            };
        }

        // Model.Materials המרת אוביקט  
        //Material לאוביקט 
        public static Material MaterialsToMaterial(Model.Materials material)
        {
            return new Material()
            {
                MaterialId = material.MaterialId,
                MaterialName = material.MaterialName,
            };
        }

    }
}