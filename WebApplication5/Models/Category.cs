using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Position { get; set; }
        public string CreatedAt { get; set; }
    
    public Category()
        {

        }

        public Category(int categoryId, string categoryName, string description, string image, string status, string position, string createdAt)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            Image = image;
            Status = status;
            Position = position;
            CreatedAt = createdAt;
        }
    }

}