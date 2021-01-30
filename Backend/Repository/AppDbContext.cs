using Backend.Model;
using Backend.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Repository
{
    public class AppDbContext : DbContext
    {

        public DbSet<Album> Albums { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavoriteMusic> UsersPlaylist { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new AlbumMapping());
            // modelBuilder.ApplyConfiguration(new MusicMapping());
            // modelBuilder.ApplyConfiguration(new UserMapping());
            // modelBuilder.ApplyConfiguration(new UserFavoriteMusicMapping());
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        
    }
}