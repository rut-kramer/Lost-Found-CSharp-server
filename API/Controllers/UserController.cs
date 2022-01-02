using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;
using System.Web;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        UserLogic userLogic = new UserLogic();
        //EmailSending emailSending = new EmailSending();

        //GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet]
        [Route("api/User/GetUserLosts")]
        public List<Lost> GetUserLosts(string userId)
        {
            List<Lost> res= userLogic.GetUserLosts(Convert.ToInt32(userId));
            return res;
        }

        // GET: api/User/5
        [HttpGet]
        [Route("api/User/GetUserFounds")]
        public List<Found> GetUserFounds(string userId)
        {
            return userLogic.GetUserFounds(Convert.ToInt32(userId));
        }


        // GET: api/User/{userPassword}/{userName}
        public User Get(string userMail, string userPassword)
        {
            return userLogic.SignIn(userMail, userPassword);
        }

        //////////////////////// GET: api/Searches/5
        //////////////////////[HttpGet]
        //////////////////////[Route("api/User/GetUserItems/{userId}")]
        //////////////////////public List<Lost> SearchInLosts(string categoryId, string location, string radius)
        //////////////////////{
        //////////////////////    //, Convert.ToInt32(location), Convert.ToInt32(radius));
        //////////////////////    return searchLogic.UniversalSearchInLosts(Convert.ToInt32(categoryId), 0);
        //////////////////////}

        // POST: api/User
        public int Post([FromBody]User u)
        {
            //emailSending.Send(u.UserMail);
            return userLogic.SignUp(u);
        }

        [HttpPost]
        [Route("api/User/UploadLogo")]
        public string UploadLogo()
        {
            System.Web.HttpRequest httpRequest = HttpContext.Current.Request;
            System.Web.HttpPostedFile postedFile = httpRequest.Files["Image"];
            if (postedFile != null)
            {
                string filePath = HttpContext.Current.Server.MapPath("~/Images/" + postedFile.FileName);
                postedFile.SaveAs(filePath);
                return postedFile.FileName;
            }
            return null;

        }
        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
