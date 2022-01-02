using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;
using System.Text.RegularExpressions;

namespace Bll
{
    public static class PublicTranspotation
    {
        public static List<Agency> Agencies { get; }
        public static List<Route> Routes { get; }

        static PublicTranspotation()
        {
            Agencies = new List<Agency>();
            Routes = new List<Route>();

            FillAgencies();
            FillRoutes();
        }

        //public List<Agency> GetAgencies()
        //{
        //    return Agencies;
        //}
        private static void FillRoutes()
        {
            
        //C: \Users\User\ruth\Losts - Founds Project\Model\Entities\Transportation\routes.txt
            string[] lines = File.ReadAllLines(@"C: \Users\User\ruth\Losts-Founds Project\Model\Entities\Transportation\routes.txt");
            //string[] lines = File.ReadAllLines(@"C:\Users\USER\Desktop\פרויקט גמר - 20.5.19\Model\Entities\routes.txt");
            //Route lastRoute= null;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                Route route = GetRouteFromStrings(data,i);
                route= RemoveIrrelevantCharactersFromDesc(route);
                if(Routes.Count==0|| route.Description!=Routes.Last().Description /*&& route.Description != Routes.Last().Description*/)
                    Routes.Add(route);
            }
        }

        private static Route RemoveIrrelevantCharactersFromDesc(Route route)
        {
            string y;
            //route.Description.Replace(@"#", string.Empty);
            y=Regex.Replace(route.Description, "[0-9#]", string.Empty);
            route.Description = y;
            //for (int i = 0; i < route.Description.Length; i++)
            //{

            //    if (route.Description[i] == '#' || char.IsDigit(route.Description[i]))
            //    {
            //        route.Description.Remove(i, 1);
            //        i--;
            //    }
            //}
            return route;
        }

        private static Route GetRouteFromStrings(string[] data, int id)
        {
            Route route = new Route();
            route.Id = id;
            int busNumber;
            int.TryParse(data[2], out busNumber);
            route.BusNumber = busNumber;
            int agencyId;
            int.TryParse(data[1], out agencyId);
            Agency agency = Agencies.Find(ag => ag.Id == agencyId);
            route.Agency = agency;
            route.Description = data[3];
            return route;
        }

        private static void FillAgencies()
        {
            //C: \Users\User\ruth\Losts - Founds Project\Model\Entities\Transportation\agency.txt
            string path = @"C: \Users\User\ruth\Losts-Founds Project\Model\Entities\Transportation\agency.txt";
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                Agency agency = GetAgencyFromStrings(data);
                Agencies.Add(agency);
            }

        }

        private static Agency GetAgencyFromStrings(string[] data)
        {
            Agency agency = new Agency();
            int id;
            int.TryParse(data[0], out id);
            agency.Id = id;
            agency.Name = data[1];
            agency.url = data[2];
            return agency;
        }
    }
}
