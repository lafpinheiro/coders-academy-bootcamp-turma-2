using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IList<UserFavoriteMusic>> GetFavoriteMusics(Guid id)
        {
            return await this.Query.Include(x => x.FavoriteMusics)
                                   .ThenInclude(x => x.Music)
                                   .ThenInclude(x => x.Album)
                                   .Where(x => x.Id == id)
                                   .SelectMany(x => x.FavoriteMusics)
                                   .ToListAsync();
        }

        public async Task<User> Authenticate(string email, string password)
        {
            return await this.Query.Include(x => x.FavoriteMusics)
                                   .ThenInclude(x => x.Music)
                                   .ThenInclude(x => x.Album)
                                   .Where(x => x.Password == password && x.Email == email)
                                   .FirstOrDefaultAsync();
        }

        public new async Task<User> GetById(Guid id)
        {
            return await this.Query.Include(x => x.FavoriteMusics)
                                   .ThenInclude(x => x.Music)
                                   .ThenInclude(x => x.Album)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefaultAsync();
        }
    }

}