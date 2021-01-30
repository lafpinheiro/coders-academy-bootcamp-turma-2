using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Repository.Mapping
{
    public class UserFavoriteMusicMapping : IEntityTypeConfiguration<UserFavoriteMusic>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteMusic> builder)
        {
            builder.ToTable("UserFavoriteMusic");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Music).WithOne().HasForeignKey<UserFavoriteMusic>(x => x.MusicId);
            
        }
    }

}