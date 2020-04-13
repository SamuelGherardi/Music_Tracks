using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Music_Tracks.Models;

namespace Music_Tracks.Models
{
    public class Music_TracksContext : DbContext
    {
        public Music_TracksContext (DbContextOptions<Music_TracksContext> options)
            : base(options)
        {
        }

        public DbSet<Music_Tracks.Models.Track> Track { get; set; }

        public DbSet<Music_Tracks.Models.User> User { get; set; }
    }
}
