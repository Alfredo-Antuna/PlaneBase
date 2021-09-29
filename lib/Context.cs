using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace lib
{
    public class Context : DbContext
    {
        public DbSet<Flight> Flights {get; set;}
        public DbSet<Seat> Seats {get; set;}
        
        
        
        


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        var basedir = System.AppContext.BaseDirectory;
        var solndir = Directory.GetParent(basedir).Parent.Parent.Parent.Parent;
        options.UseSqlite($"Data Source={solndir.FullName}/Data/app.db");
        options.EnableSensitiveDataLogging();



        }
    }
}
