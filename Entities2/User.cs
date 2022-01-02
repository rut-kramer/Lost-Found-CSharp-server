using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurProject.Models
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

        // Model.Users המרת אוביקט  
        //User לאוביקט 

        public static User UsersToUser(Model.Users user)
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
                UserStatus = user.UserStatus
            };
        }
        // User המרת אוביקט  
        //Model.Users לאוביקט 
        public static Model.Users UserToUsers(User user)
        {
            return new Model.Users()
            {
                UserAddress = user.UserAddress,
                UserId = user.UserId,
                UserImage = user.UserImage,
                UserMail = user.UserMail,
                UserMobile = user.UserMobile,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                UserStatus = user.UserStatus
            };
        }


    }
}