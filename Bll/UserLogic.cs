using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Model;
using Entities;

namespace Bll
{
    public class UserLogic
    {
        //Model.LostAndFoundEntities db = new Model.LostAndFoundEntities();
        Model.HashavatAvedaEntities db = new Model.HashavatAvedaEntities();
        EmailSending emailSending = new EmailSending();

        //פונקציה לכניסת משתמש
        public User SignIn(string userMail, string userPassword)
        {
            Model.User user = db.Users.FirstOrDefault(x => x.UserMail == userMail);

            User castUser = null;
            if (user != null && user.UserPassword == userPassword)
            {
                castUser = User.UsersToUser(user);
            }

            return castUser;
        }

        //פונקציה לרישום משתמש חדש
        public int SignUp(User u)
        {
            //המרת משתמש
            Model.User user = User.UserToUsers(u);
            Model.User users = db.Users.FirstOrDefault(x => x.UserMail == u.UserMail);
            if (users == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                try
                {
                    emailSending.SendNewUSER(u.UserMail);
                }
                catch { }
                Model.User u1 = db.Users.FirstOrDefault(x => x.UserMail == u.UserMail); ;
                return Convert.ToInt32(u1.UserId);
            }
            return 0;
        }
        public List<Lost> GetUserLosts(int id)
        {
            List<Model.Lost> losts = db.Losts.Where(x => x.UserId == id).ToList();
            return Lost.ListLostsToListLost(losts);
        }
        public List<Found> GetUserFounds(int id)
        {
            List<Model.Found> founds = db.Founds.Where(x => x.UserId == id).ToList();
            return Found.ListFoundsToFound(founds);
        }
    }
}
