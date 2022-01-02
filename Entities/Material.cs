using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Material
    {
        public decimal MaterialId { get; set; }
        public string MaterialName { get; set; }
        //Material המרת אוביקט  
        // Model.Materials לאוביקט 
        public static Model.Material MaterialToMaterials(Material material)
        {
            return new Model.Material()
            {
                MaterialId = material.MaterialId,
                MaterialName = material.MaterialName,
            };
        }
        // Material המרת רשימת  
        //Model.Materials לרשימת 
        public static List<Model.Material> ListMaterialToListMaterials(List<Material> Materials)
        {
            List<Model.Material> m = new List<Model.Material>();
            foreach (Material item in Materials)
            {
                Model.Material material = MaterialToMaterials(item);
                m.Add(material);
            }
            return m;
        }


        // Model.Materials המרת אוביקט  
        //Material לאוביקט 
        public static Material MaterialsToMaterial(Model.Material material)
        {
            return new Material()
            {
                MaterialId = material.MaterialId,
                MaterialName = material.MaterialName,
            };
        }

        // Model.Categories המרת רשימת  
        //Category לרשימת 
        public static List<Material> ListMaterialsToListMaterial(List<Model.Material> Materials)
        {
            List<Material> m = new List<Material>();
            foreach (Model.Material item in Materials)
            {
                Material material = MaterialsToMaterial(item);
                m.Add(material);
            }
            return m;
        }

    }
}