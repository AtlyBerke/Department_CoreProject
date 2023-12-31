﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Departman.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP; database=DBCoreProject1; integrated security=true;");
        }

        public DbSet<Personel> Personels { get; set; }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
