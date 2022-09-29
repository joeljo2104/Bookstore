using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ShippingAddress { get; set; }

        public User()
        {

        }

        public User(int userId, string userName, string password, string name, string shippingAddress)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Name = name;
            ShippingAddress = shippingAddress;
        }
    }
}