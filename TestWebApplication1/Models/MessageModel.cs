using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

using System.ComponentModel.DataAnnotations;

using Languages2;

namespace TestWebApplication1.Models
{
    public class MessageModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Display(Name = "Message", ResourceType = typeof(Resource))]
        public string Message { get; set; }

    }

    public class MessageDbContext: DbContext
    {
        public DbSet<MessageModel> Messages { get; set; }
    }
}