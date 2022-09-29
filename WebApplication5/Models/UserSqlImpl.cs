using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication5.Models
{
    public class UserSqlImpl : IUserRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public UserSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public User AddUser(User user)
        {
            comm.CommandText = "insert into Users (UserName, Password, Name, ShippingAddress) values ('" + user.UserName + "', '" + user.Password + "', '" + user.Name + "', '" + user.ShippingAddress + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public void DeleteUser(int id)
        {
            comm.CommandText = "delete from Users where UserId = " + id;
            comm.Connection = conn;
            conn.Open();
            conn.Close();
        }

        public List<User> GetAllUser()
        {
            List<User> list = new List<User>();
            comm.CommandText = "select * from Users";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int UserId = Convert.ToInt32(reader["UserId"]);
                string UserName = reader["UserName"].ToString();
                string Name = reader["Name"].ToString();
                string ShippingAddress = reader["ShippingAddress"].ToString();

                list.Add(new User(UserId, UserName, "******", Name, ShippingAddress));
            }
            conn.Close();
            return list;
        }

        public User GetUserById(int id)
        {
            comm.CommandText = "select * from Users where UserId" + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int UserId = Convert.ToInt32(reader["UserId"]);
                string UserName = reader["UserName"].ToString();
                string Name = reader["Name"].ToString();
                string ShippingAddress = reader["ShippingAddress"].ToString();

                User user = new User(UserId, UserName, "******", Name, ShippingAddress);
                conn.Close(); 
                return user;
            }
            return null;
        }

        public void UpdateUser(User user)
        {
            comm.CommandText = "update Users set UserName=" + user.UserName + "', 'Name=" + user.Name + "', 'ShippingAddress=" + user.ShippingAddress + "' where UserId =  '" + user.UserId;
            comm.Connection = conn;
            conn.Open();
            conn.Close();
        }
    }
}