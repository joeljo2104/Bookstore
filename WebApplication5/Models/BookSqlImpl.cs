using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication5.Models
{
    public class BookSqlImpl : IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Book (CategoryId, Title, ISBN, Year, Price, Description, Position, Status, Image) values ('" + book.CategoryID + "', '" + book.Title + "', '" + book.ISBN + "', '" + book.Year + "', '" + book.Price + "', '" + book.Description + "', '" + book.Position + "', '" + book.Status + "', '" + book.Image + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            if (row > 0)
            {
                return book;
            } else
            {
                return null;
            }
            conn.Close();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBook()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while(reader.Read())
            {
                int BookId = Convert.ToInt32(reader["BookId"]);
                int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                string Title = reader["Title"].ToString();
                string ISBN = reader["ISBN"].ToString();
                int Year = Convert.ToInt32(reader["Year"]);
                int Price = Convert.ToInt32(reader["Price"]);
                string Description = reader["Description"].ToString();
                string Position = reader["Position"].ToString();
                string Status = reader["Status"].ToString();
                string Image = reader["Image"].ToString();

                list.Add(new Book(BookId, CategoryId, Title, ISBN, Year, Price, Description, Position, Status, Image));
            }
            conn.Close();
            return list;
        }

        public Book GetBookById(int id)
        {
            comm.CommandText = "select * from Book where BookId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int BookId = Convert.ToInt32(reader["BookId"]);
                int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                string Title = reader["Title"].ToString();
                string ISBN = reader["ISBN"].ToString();
                int Year = Convert.ToInt32(reader["Year"]);
                int Price = Convert.ToInt32(reader["Price"]);
                string Description = reader["Description"].ToString();
                string Position = reader["Position"].ToString();
                string Status = reader["Status"].ToString();
                string Image = reader["Image"].ToString();

                Book book = new Book(BookId, CategoryId, Title, ISBN, Year, Price, Description, Position, Status, Image);
                return book;
            }
            conn.Close();
            return null; ;
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}