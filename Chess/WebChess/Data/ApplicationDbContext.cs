using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebChess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ChessParty> ChessParties { get; set; }
        public DbSet<DeskState> DeskStates { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
