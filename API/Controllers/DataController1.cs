using Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;

namespace API.Controllers
{
    public class DataController : ApiController
    {
        DataLogic dataLogic = new DataLogic();
        SearchLogic searchLogic = new SearchLogic();
        EmailSending emailSending = new EmailSending();

        // GET: api/Data
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Data/GetCategories
        [HttpGet]
        [Route("api/Data/GetCategories")]
        public List<Category> GetCategories()
        {
            return dataLogic.GetCategories();
        }
        [HttpGet]
        [Route("api/Data/GetCompanies")]
        public List<User> GetCompanies()
        {
            return dataLogic.GetCompanies();
        }
        // GET: api/Data/GetAgency
        [HttpGet]
        [Route("api/Data/GetAgency")]
        public List<Agency> GetAgency()
        {
            return PublicTranspotation.Agencies;
        }
        [HttpGet]
        [Route("api/Data/GetRoutes")]
        public List<Route> GetRoutes()
        {
            return Bll.PublicTranspotation.Routes;

            //PublicTranspotation.Routes;
        }

        // GET: api/Data/GetItems
        [HttpGet]
        [Route("api/Data/GetItems")]
        public List<Item> GetItems()
        {
            return dataLogic.GetItems();
        }

        // GET: api/Data/GetMaterial
        [HttpGet]
        [Route("api/Data/GetMaterial")]
        public List<Material> GetMaterial()
        {
            return dataLogic.GetMaterials();
        }

        // GET: api/Data/GetColors
        [HttpGet]
        [Route("api/Data/GetColors")]
        public List<Color> GetColors()
        {
            return dataLogic.GetColors();
        }

        //    // GET: api/Data/5
        //    public string Get(int id)
        //{
        //    return "value";
        //}

        //שמירה
        // POST: api/Data
        [HttpPost]
        [Route("api/Data/SaveFound")]
        public List<Lost> SaveFound([FromBody] Found found)
        {
            dataLogic.AddNewFound(found);
            List<Lost> l = searchLogic.SearchInLostsWithManyParams(found);
            return l;
        }
        //חיפוש
        [HttpPost]
        [Route("api/Data/SearchFound")]
        public List<Lost> SearchFound([FromBody] Found found)
        {
            return searchLogic.SearchInLostsWithManyParams(found);
        }
        //עדכון
        [HttpPost]
        [Route("api/Data/UpdateFound")]
        public bool UpdateFound([FromBody] Found found)
        {
            try
            {
                dataLogic.UpdateFound(found);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        //מחיקה
        [HttpPost]
        [Route("api/Data/DeleteFound")]
        public bool DeleteFound([FromBody] Found found)
        {
            try
            {
                dataLogic.RemoveFound(found);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //הושב לבעליו
        [HttpGet]
        [Route("api/Data/UpdateFoundStatus")]
        public bool UpdateFoundStatus(string id)
        {
            try
            {
                dataLogic.UpdateFoundStatus(Convert.ToInt32(id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //שמירה
        [HttpPost]
        [Route("api/Data/SaveLost")]
        public List<Found> SaveLost([FromBody] Lost lost)
        {
            dataLogic.AddNewLost(lost);
            List<Found> f = searchLogic.SearchInFoundsWithManyParams(lost);
            return f;
        }

        //חיפוש
        [HttpPost]
        [Route("api/Data/SearchLost")]
        public List<Found> SearchLost([FromBody] Lost lost)
        {
            return searchLogic.SearchInFoundsWithManyParams(lost);
        }
        //עדכון
        [HttpPost]
        [Route("api/Data/UpdateLost")]
        public bool UpdateLost([FromBody] Lost lost)
        {
            try
            {
                dataLogic.UpdateLost(lost);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        //מחיקה
        [HttpPost]
        [Route("api/Data/DeleteLost")]
        public bool DeleteLost([FromBody] Lost lost)
        {
            try
            {
                dataLogic.RemoveLost(lost);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //הושב לבעליו
        [HttpGet]
        [Route("api/Data/UpdateLostStatus")]
        public bool UpdateLostStatus(string id)
        {
            try
            {
                dataLogic.UpdateLostStatus(Convert.ToInt32(id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //מייל
        [HttpGet]
        [Route("api/Data/mail")]
        public bool Mail(string text, string id, string isLost)
        {
            try
            {
                bool isLos = Convert.ToBoolean(isLost);
                if (isLos)
                {
                    emailSending.SendDrishaL(text, Convert.ToInt32(id));
                    return true;
                }
                else
                {
                    emailSending.SendDrishaF(text, Convert.ToInt32(id));
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }




        // PUT: api/Data/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Data/5
        public void Delete(int id)
        {
        }
    }
}
