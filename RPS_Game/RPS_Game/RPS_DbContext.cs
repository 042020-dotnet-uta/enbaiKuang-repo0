using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    public class RPS_DbContext : DbContext
    {
        public DbSet<Game> Games{ set; get;}
        public DbSet<Round> Rounds { set; get; }
        public DbSet<Player> Players { set; get; }

        public RPS_DbContext() { }

        public RPS_DbContext(DbContextOptions<RPS_DbContext> options) : base(options){
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            if (!options.IsConfigured) {
                options.UseSqlite("Data Source = RPS_Game.db");
            }
        }
    }
}
