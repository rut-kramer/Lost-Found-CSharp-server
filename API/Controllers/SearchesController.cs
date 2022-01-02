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
    public class SearchesController : ApiController
    {
        SearchLogic searchLogic = new SearchLogic();
        // GET: api/Searches
        public List<Lost> Get()
        {
            return null;
        }
///{categoryId}/{locationlat}/{locationlng}/{radius}
        // GET: api/Searches/5
        [HttpGet]
        [Route("api/Searches/SearchInLosts")]
        public List<Lost> SearchInLosts(string categoryId, string locationlat, string locationlng, string radius)
        {
            double lng, lat;
            Double.TryParse(locationlng, out lng);
            Double.TryParse(locationlat, out lat);
            return searchLogic.UniversalSearchInLosts(Convert.ToInt32(categoryId), lat, lng, Convert.ToDouble(radius));
        }

        //[HttpGet]
        //[Route("api/Searches/SearchInLostsScore")]
        //public List<Lost> SearchInLostsScore([FromBody]Found found)
        //{
        //    return searchLogic.SearchInLostsWithManyParams(found);
        //}
        ///api/Searches/SearchInFounds/

        // GET: api/Searches/5
        [HttpGet]
        [Route("api/Searches/SearchInFounds")]
        public List<Found> SearchInFounds(string categoryId, string locationlat, string locationlng, string radius)
        {
            double lng, lat;
            Double.TryParse(locationlng, out lng);
            Double.TryParse(locationlat, out lat);
            return searchLogic.UniversalSearchInFounds(Convert.ToInt32(categoryId), lat, lng, Convert.ToDouble(radius));
        }
        // POST: api/Searches
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Searches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Searches/5
        public void Delete(int id)
        {
        }
    }
}
