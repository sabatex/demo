using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxRegisterImport.Models;

namespace TaxRegisterImport.Data
{
    public class RegisterDbContext:DbContext
    {
        public DbSet<RegisterTax> MyProperty { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"FileName=c:\\DataBases\Register.db");
        }
    }
}
