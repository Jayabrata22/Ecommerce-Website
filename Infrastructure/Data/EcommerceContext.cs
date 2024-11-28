using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EcommerceContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products {  get; set; }
    }
}
