using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication5.Models
{
    public class CategorySqlImpl : ICategoryRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public CategorySqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Category AddCategory(Category category)
        {
            comm.CommandText = "insert into Category (CategoryName, Description, Image, Status, Position, CreatedAt) values ('" + category.CategoryName + "', '" + category.Description + "', '" + category.Image + "', '" + category.Status + "', '" + category.Position + "', '" + category.CreatedAt + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public void DeleteCategory(int id)
        {
            comm.CommandText = "delete from Category where CategoryId = " + id;
            comm.Connection = conn;
            conn.Open();
            conn.Close();
        }

        public List<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                string CategoryName = reader["CategoryName"].ToString();
                string Description = reader["Description"].ToString();
                string Image = reader["Image"].ToString();
                string Status = reader["Status"].ToString();
                string Position = reader["Position"].ToString();
                string CreatedAt = reader["CreatedAt"].ToString();

                list.Add(new Category(CategoryId, CategoryName, Description, Image, Status, Position, CreatedAt));
            }
            conn.Close();
            return list;
        }

        public Category GetCategoryById(int id)
        {
            comm.CommandText = "select * from Category where CategoryId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                string CategoryName = reader["CategoryName"].ToString();
                string Description = reader["Description"].ToString();
                string Image = reader["Image"].ToString();
                string Status = reader["Status"].ToString();
                string Position = reader["Position"].ToString();
                string CreatedAt = reader["CreatedAt"].ToString();

                Category category = new Category(CategoryId, CategoryName, Description, Image, Status, Position, CreatedAt));

                conn.Close();
                return category;
            }

            return null; ;
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}