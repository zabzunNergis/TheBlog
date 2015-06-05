using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Article
    {
        public int ID { get; set; }
       
        [Required]
        public string Title { get; set; }
       
        [DataType(DataType.Date)]
        [Required]
        public DateTime CreationDate { get; set; }

        [AllowHtml]
        [Required]
        public string Body { get; set; }
        
        [Required]
        public string author { get; set; }
        
    }

    public class ArticleDBContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}