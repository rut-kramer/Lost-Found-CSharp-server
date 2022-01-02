using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class User
    {
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserMobile { get; set; }
        public bool UserStatus { get; set; }
        public string UserImage { get; set; }
        public string UserAddress { get; set; }
        public double UserLat { get; set; }
        public double UserLng { get; set; }
        
        // Model.Users המרת אוביקט  
        //User לאוביקט 

        public static User UsersToUser(Model.User user)
        {
            return new User()
            {
                UserAddress = user.UserAddress,
                UserId = user.UserId,
                UserImage = user.UserImage,
                UserMail = user.UserMail,
                UserMobile = user.UserMobile,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                UserStatus = user.UserStatus,
                UserLat = Convert.ToDouble(user.UserLat),
                UserLng = Convert.ToDouble(user.UserLng)
            };
        }
        // User המרת אוביקט  
        //Model.Users לאוביקט 
        public static Model.User UserToUsers(User user)
        {
            return new Model.User()
            {
                UserAddress = user.UserAddress,
                UserId = user.UserId,
                UserImage = user.UserImage,
                UserMail = user.UserMail,
                UserMobile = user.UserMobile,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                UserStatus = user.UserStatus,
                UserLat = user.UserLat,
                UserLng = user.UserLng
            };
        }


        // Model.Users המרת רשימת  
        //User לרשימת 
        public static List<User> ListUsersToListUser(List<Model.User> Users)
        {
            List<User> m = new List<User>();
            foreach (Model.User item in Users)
            {
                User user = UsersToUser(item);
                m.Add(user);
            }
            return m;
        }


    }
}