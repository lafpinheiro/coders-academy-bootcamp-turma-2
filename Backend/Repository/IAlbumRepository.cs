using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository
{
    public interface IAlbumRepository
    {
        Task<IList<Album>> GetAll();
        Task<IList<Music>> GetMusicFromAlbum(Guid albumId);
        Task<Music> GetMusic(Guid musicId);
        Task<Album> GetById(Guid id);
        Task Save(Album obj);
        Task Remove(Album obj);

    }
}