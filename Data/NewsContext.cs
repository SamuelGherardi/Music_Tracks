using Microsoft.EntityFrameworkCore; //libreria che mi occorre per utilizzare tutti gli strumenti di Entity Framework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_Tracks.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public DbSet<Music_Tracks.Models.News> News { get; set; }
    }
}
