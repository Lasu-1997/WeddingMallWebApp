﻿using Microsoft.EntityFrameworkCore;

namespace WeddingMallWebApp.Models
{
    public class WeddingDBContext : DbContext
    {
        public WeddingDBContext(DbContextOptions<WeddingDBContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; } = null;
        public DbSet<Category> Category { get; set; } = null;
        public DbSet<Service> Service { get; set; } = null;

    }
}
