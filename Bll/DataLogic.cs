using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
//using Model;


namespace Bll
{
    public class DataLogic
    {
        //Model.LostAndFoundEntities db = new Model.LostAndFoundEntities();
        Model.HashavatAvedaEntities db = new Model.HashavatAvedaEntities();

        //שולף ומחזיר את כל החברות ממסד הנתונים
        public List<User> GetCompanies()
        {

            return User.ListUsersToListUser(db.Users.ToList()).FindAll(x => x.UserStatus == true);
        }
        //שולף ומחזיר את כל הקטגוריות ממסד הנתונים
        public List<Category> GetCategories()
        {
            return Category.ListCategoriesToListCategory(db.Categories.ToList());
        }

        //שולף ומחזיר את כל הפריטים ממסד הנתונים
        public List<Item> GetItems()
        {
            return Item.ListItemsToListItem(db.Items.ToList());
        }

        //שולף ומחזיר את כל סוגי החומרים ממסד הנתונים
        public List<Material> GetMaterials()
        {
            return Material.ListMaterialsToListMaterial(db.Materials.ToList());
        }
        //שולף ומחזיר את כל הצבעים ממסד הנתונים
        public List<Color> GetColors()
        {
            return Color.ListColorsToListColor(db.Colors.ToList());
        }

        //הוספת אבידה חדשה למסד
        public void AddNewLost(Lost lost)
        {
            Model.Lost l = Lost.LostToLosts(lost);
            db.Losts.Add(l);
            db.SaveChanges();
        }
        //עדכון אבידה
        public void UpdateLost(Lost lost)
        {
            Model.Lost newl = Lost.LostToLosts(lost);
            Model.Lost oldl = db.Losts.FirstOrDefault(o => o.LostId == newl.LostId);
            oldl = newl;
            //oldl.ItemName = newl.ItemName;
            //oldl.LostDescription = newl.LostDescription;
            //oldl.LostImage = newl.LostImage;
            //oldl.LostLat = newl.LostLat;
            //oldl.LostLng = newl.LostLng;
            oldl.CategoryId = newl.CategoryId;
            oldl.ItemId = newl.ItemId;
            oldl.ItemName = newl.ItemName;
            oldl.LostDate = newl.LostDate;
            oldl.LostDescription = newl.LostDescription;
            oldl.LostAddress = newl.LostAddress;
            oldl.LostLat = newl.LostLat;
            oldl.LostLng = newl.LostLng;
            oldl.Material = newl.Material;
            oldl.color1 = newl.color1;
            oldl.color2 = newl.color2;
            oldl.color3 = newl.color3;

            db.SaveChanges();
        }


        //מחיקת אבידה מהמסד
        public void RemoveLost(Lost lost)
        {
            Model.Lost l = db.Losts.FirstOrDefault(i => i.LostId == lost.LostId);
            db.Losts.Remove(l);
            db.SaveChanges();
        }


        //הוספת מציאה חדשה למסד
        public void AddNewFound(Found f)
        {
            Model.Found found = Found.FoundToFounds(f);
            db.Founds.Add(found);
            db.SaveChanges();
        }
        //עדכון מציאה
        public void UpdateFound(Found found)
        {
            Model.Found newl = Found.FoundToFounds(found);
            Model.Found oldl = db.Founds.FirstOrDefault(o => o.FoundId == newl.FoundId);
            oldl.CategoryId = newl.CategoryId;
            oldl.ItemId = newl.ItemId;
            oldl.ItemName = newl.ItemName;
            oldl.FoundDate = newl.FoundDate;
            oldl.FoundDescription = newl.FoundDescription;
            oldl.FoundAddress = newl.FoundAddress;
            oldl.FoundLat = newl.FoundLat;
            oldl.FoundLng = newl.FoundLng;
            oldl.Material = newl.Material;
            oldl.color1 = newl.color1;
            oldl.color2 = newl.color2;
            oldl.color3 = newl.color3;
            //oldl.ItemName = newl.ItemName;
            //oldl.LostDescription = newl.LostDescription;
            //oldl.LostImage = newl.LostImage;
            //oldl.LostLat = newl.LostLat;
            //oldl.LostLng = newl.LostLng;
            db.SaveChanges();
        }
        //מחיקת מציאה מהמסד
        public void RemoveFound(Found f)
        {
            Model.Found found = db.Founds.FirstOrDefault(i => i.FoundId == f.FoundId);
            db.Founds.Remove(found);
            db.SaveChanges();
        }
        public void UpdateFoundStatus(int id)
        {
            Model.Found found = db.Founds.FirstOrDefault(i => i.FoundId == id);
            found.FoundStatus = true;
            db.SaveChanges();
        }

        public void UpdateLostStatus(int id)
        {
            Model.Lost l = db.Losts.FirstOrDefault(i => i.LostId == id);
            l.LostStatus = true;
            db.SaveChanges();
        }

    }
}

