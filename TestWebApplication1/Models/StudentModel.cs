using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

using System.ComponentModel.DataAnnotations;

namespace TestWebApplication1.Models
{
    public class StudentModel
    {
        [Key]
        public int IdStudent { get; set; }

        public string Nume { get; set; }

    }

    public class StudentDbContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
    }
}