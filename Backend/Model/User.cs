using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Backend.Model
{
    public class User
    {
        public User()
        {
            this.FavoriteMusics = new List<UserFavoriteMusic>();
        }

        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        
        [JsonIgnore]
        public String Password { get; set; }
        
        public String Photo { get; set; }
        
        public IList<UserFavoriteMusic> FavoriteMusics { get; set; }
        

        public void AddFavoriteMusic(Music music)
        {
            this.FavoriteMusics.Add(new UserFavoriteMusic()
            {
                Music = music,
                MusicId = music.Id,
                User = this,
                UserId = this.Id
            });
        }

        public void RemoveFavoriteMusic(Music music)
        {
            var favoriteMusic = this.FavoriteMusics.FirstOrDefault(x => x.MusicId == music.Id);
            this.FavoriteMusics.Remove(favoriteMusic);
        }
        
    }

    
}