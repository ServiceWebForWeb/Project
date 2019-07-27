using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebService.Models;

namespace MyWebService.Models
{
    public class MyWebServiceContext : DbContext
    {
        public MyWebServiceContext (DbContextOptions<MyWebServiceContext> options)
            : base(options)
        {
        }

        public DbSet<MyWebService.Models.Projetos> Projetos { get; set; }

        public DbSet<MyWebService.Models.SingUp> SingUp { get; set; }
    }
}
