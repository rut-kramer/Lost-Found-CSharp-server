using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Model;

namespace Bll
{
    public class SearchLogic
    {
        //Model.LostAndFoundEntities db = new Model.LostAndFoundEntities();
        Model.HashavatAvedaEntities db = new Model.HashavatAvedaEntities();
        int i;

        //חיפוש כללי במציאות
        //ע[דיין לא] __עובד
        public List<Found> UniversalSearchInFounds(decimal categoryId, double lat, double lng, double radius)
        {
            List<Model.Found> founds = new List<Model.Found>();
            //עובר על כל המציאות משווה קטגוריה ומיקום
            foreach (var f in db.Founds)
            {
                if (f.CategoryId == categoryId && Distance(Convert.ToDouble(f.FoundLat), Convert.ToDouble(f.FoundLng), lat, lng) < radius)
                {
                    founds.Add(f);
                }
            }
            return Found.ListFoundsToFound(founds);
        }

        //חיפוש לפי פרמטרים רבים
        public List<Found> SearchInFoundsWithManyParams(Lost myFound)
        {
            //איך להתייחס לקטגורית אחר?
            List<Found> suitableLosts = new List<Found>();
            //סינון ראשוני לפי קטגוריה ופריט
            List<Found> losts = UniversalSearchInFounds(myFound.CategoryId, Convert.ToDouble(myFound.LostLat), Convert.ToDouble(myFound.LostLng), 1500);/*-!!!!!לשנות את החומר לרדיוס!!!!=*/

            foreach (var item in losts)
            {
                //losts.Max(/*Func<Found,decimal>*/item.CategoryId);//מציאת הניקוד המקסימלי
                //איפוס הערך המקסימלי
                //הוספת המציאה במיקום הערך
                //losts.ElementAt(5);
            }
            //רשימה מסודרת לפי התאמה
            //suitableLosts.AddRange(SuitableLevel1(ref losts, myFound));
            suitableLosts.Add(new Found());
            //suitableLosts.AddRange(SuitableLevel2(ref losts, myFound));
            suitableLosts.Add(new Found());
            //suitableLosts.AddRange(SuitableLevel3(ref losts, myFound));
            suitableLosts.Add(new Found());
            //return suitableLosts;       
            return losts;
        }

        //חיפוש כללי באבדות
        public List<Lost> UniversalSearchInLosts(decimal categoryId, double lat, double lng, double radius)
        {
            List<Model.Lost> lost = new List<Model.Lost>();
            //עובר על כל האבידות משווה קטגוריה ומיקום
            foreach (var l in db.Losts)
            {
                if (l.CategoryId == categoryId && Distance(Convert.ToDouble(l.LostLat), Convert.ToDouble(l.LostLng), lat, lng) < radius)
                {
                    lost.Add(l);
                }
            }
            return Lost.ListLostsToListLost(lost);
        }

        //חיפוש לפי פרמטרים רבים
        public List<Lost> SearchInLostsWithManyParams(Found myFound)
        {
            //איך להתייחס לקטגורית אחר?
            List<Lost> suitableLosts = new List<Lost>();
            //סינון ראשוני לפי קטגוריה ופריט
            List<Lost> losts = UniversalSearchInLosts(myFound.CategoryId, Convert.ToDouble(myFound.FoundLat), Convert.ToDouble(myFound.FoundLng), 1500);/*-!!!!!לשנות את החומר לרדיוס!!!!=*/


            //רשימה מסודרת לפי התאמה
            suitableLosts.AddRange(SuitableLevel1(ref losts, myFound));
            suitableLosts.Add(new Lost());
            suitableLosts.AddRange(SuitableLevel2(ref losts, myFound));
            suitableLosts.Add(new Lost());
            suitableLosts.AddRange(SuitableLevel3(ref losts, myFound));
            suitableLosts.Add(new Lost());
            return suitableLosts;
        }

        //פונקציה לסינון ברמת התאמה הגבוהה ביותר
        //הסינון יתבצע על פי התאמת החומר, צבע אחד לפחות, תאריך בטווח של שבוע, לפחות מילה זהה בתאור 
        public List<Lost> SuitableLevel1(ref List<Lost> losts, Found myFound)
        {
            List<Lost> suitableLevel1 = new List<Lost>();
            //int len = losts.Count;
            //for (int i = len - 1; i >= 0; i--)
            //{
            //    if (IsSameMaterial(myFound, losts[i]) && IsSuitableColor(myFound, losts[i])
            //                   && IsSuitableDateLevel1(myFound, losts[i]) && IsSuitableDescription(myFound, losts[i]))
            //        suitableLevel1.Add(losts[i]);
            //    losts.Remove(losts[i]);
            //}
            foreach (Lost x in losts)
            {
                if (IsSameMaterial(myFound, x) && IsSuitableColor(myFound, x)
                               && IsSuitableDateLevel1(myFound, x) && IsSuitableDescription(myFound, x))
                    suitableLevel1.Add(x);
            }
            return suitableLevel1;
        }

        //פונקציה לסינון ברמת התאמה השניה 
        //הסינון יתבצע על פי התאמת החומר, תאריך בטווח של 30 יום, לפחות מילה זהה בתאור
        public List<Lost> SuitableLevel2(ref List<Lost> losts, Found myFound)
        {
            List<Lost> suitableLevel2 = new List<Lost>();
            foreach (Lost x in losts)
            {
                if (IsSameMaterial(myFound, x) && IsSuitableDateLevel2(myFound, x)
                    && IsSuitableDescription(myFound, x))
                    suitableLevel2.Add(x);
            }
            return suitableLevel2;
            //int len = losts.Count;
            //for (int i = 0; i < len; i++)
            //{
            //    if (IsSameMaterial(myFound, losts[i]) && IsSuitableDateLevel2(myFound, losts[i])
            //        && IsSuitableDescription(myFound, losts[i]))
            //        suitableLevel2.Add(losts[i]);
            //    losts.Remove(losts[i]);
            //}

        }

        //פונקציה לסינון ברמת התאמה השלישית 
        //הסינון יתבצע על פי תאריך בטווח של שנה
        public List<Lost> SuitableLevel3(ref List<Lost> losts, Found myFound)
        {
            List<Lost> suitableLevel3 = new List<Lost>();
            //int len = losts.Count;
            //for (int i = 0; i < len; i++)
            //{
            //    if (IsSuitableDateLevel3(myFound, losts[i]))
            //        suitableLevel3.Add(losts[i]);
            //    losts.Remove(losts[i]);
            //}
            foreach (Lost x in losts)
            {
                if (IsSuitableDateLevel3(myFound, x))
                    suitableLevel3.Add(x);
            }
            return suitableLevel3;
        }

        //בדיקה האם החומר זהה
        public bool IsSameMaterial(Found myFound, Lost l)
        {
            return l.MaterialId == myFound.MaterialId;
        }
        //מחזיר ניקוד התאריך לפי טווח התאריך
        public int DateScore(Found myFound, Lost l)
        {
            int difference = Math.Abs(DateTime.Compare(myFound.FoundDate, l.LostDate));
            if (difference <= 7)
                return 8-difference;
            else
                return Convert.ToInt32(difference * -0.5);
        }

        // בדיקה האם טווח התאריך מתאים לרמה ראשונה 
        public bool IsSuitableDateLevel1(Found myFound, Lost l)
        {
            return Math.Abs(DateTime.Compare(myFound.FoundDate, l.LostDate)) <= 7;
        }

        // בדיקה האם טווח התאריך מתאים לרמה שניה
        public bool IsSuitableDateLevel2(Found myFound, Lost l)
        {
            return Math.Abs(DateTime.Compare(myFound.FoundDate, l.LostDate)) <= 30;
        }

        // בדיקה האם טווח התאריך מתאים לרמה שלישית
        public bool IsSuitableDateLevel3(Found myFound, Lost l)
        {
            return Math.Abs(DateTime.Compare(myFound.FoundDate, l.LostDate)) <= 365;
        }

        //בדיקה האם יש לפחות צבע זהה
        public bool IsSuitableColor(Found myFound, Lost l)
        {
            return true;
        }

        //מחזיר ניקוד לתיאור לפי מספר המילים השוות
        public int DescriptionScore(Found myFound, Lost l)
        {
            int num = 0;
            string[] found = myFound.FoundDescription.Split(' ');
            string[] lost = l.LostDescription.Split(' ');
            for (int i = 0; i < found.Length; i++)
            {
                for (int j = 0; j < lost.Length; j++)
                {
                    if (found[i].Equals(lost[j]))
                        num += 5;
                }
            }
            return num;
        }

        //בדיקה אם יש מילה זהה בתאורים
        public bool IsSuitableDescription(Found myFound, Lost l)
        {
            //-----------------------28.07.2019----------------------------
            //יש לבדוק פונקציה מתאימה איך להשוות מחרוזות
            //---------------------------------------------------
            return myFound.FoundDescription.SequenceEqual(l.LostDescription);
        }


        //פונקציה למציאת מרחק בין 2 נקודות
        //מקבלת 4 דאבלים מחזירה דאבל של מרחק
        // Function to calculate distance 
        static double Distance(double x1, double y1, double x2, double y2)
        {
            // Calculating distance 
            double d = 100000.0 * (Math.Sqrt(Math.Pow(x2 - x1, 2) +
                          Math.Pow(y2 - y1, 2) * 1.0));
            return d;
        }
    }
}


//פונקציות מרחק
//private bool IsInRadius1(double Lat1, double Lng1, double? Lat2, double? Lng2, double radius)
//{
//    double x1= Convert.ToDouble(Lat1);
//    double y1 = Convert.ToDouble(Lng1);
//    double x2= Convert.ToDouble(Lat2);
//    double y2= Convert.ToDouble(Lng2);
//    //Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) * 1.0);
//    if (Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) * 1.0) < radius)
//        return true;
//    else
//    throw new NotImplementedException();
//}

//&& IsInRadius1(lat,lng, Convert.ToDouble(x.LostLat), Convert.ToDouble(x.LostLng) ,radius )
