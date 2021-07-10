using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IConfiguration _config;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IConfiguration config)
            : base(options)
        {
            _config = config;
        }
        public DbSet<School> Schools { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
