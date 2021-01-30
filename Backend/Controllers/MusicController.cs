using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Repository;
using Backend.Model;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private AlbumRepository AlbumRepository { get; set; }

        public MusicController(AlbumRepository repository)
        {
            this.AlbumRepository = repository;

        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var music = await this.AlbumRepository.GetMusicFromAlbum(id);

            return Ok(music);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var music = await this.AlbumRepository.GetMusic(id);

            return Ok(music);
        }

        [HttpPost("{albumId}")]
        public async Task<IActionResult> Post(Guid albumId, Music model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var album = await this.AlbumRepository.GetById(albumId);

            album.Musics.Add(model);

            await this.AlbumRepository.Update(album);

            return Ok();
        }

       
    }
}