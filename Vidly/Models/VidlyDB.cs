using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Data
{
    public class VidlyDB : DbContext
    {
       public VidlyDB(DbContextOptions<VidlyDB> options)
            : base(options){ }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
