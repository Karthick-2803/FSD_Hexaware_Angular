using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Class_Web.DAL.Models;

namespace Class_Web.DAL.Data
{
    public class Class_WebDbContext : DbContext
    {
        public Class_WebDbContext(DbContextOptions<Class_WebDbContext> options) : base(options) { }

        public DbSet<EventDetails> Events { get; set; }
        public DbSet<UserInfo> Users { get; set; }
    }
}
