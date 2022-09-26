using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int CategoryID { get; set; }
        public string ISBN { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }

        public Book()
        {

        }

        public Book(int bookId, int categoryID, string title,  string iSBN, int price, int year, string description, string position, string status, string image)
        {
            BookId = bookId;
            Title = title;
            CategoryID = categoryID;
            ISBN = iSBN;
            Price = price;
            Year = year;
            Description = description;
            Position = position;
            Status = status;
            Image = image;
        }
    }
}