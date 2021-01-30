using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private AlbumRepository Repository { get; set; }
        public AlbumController(AlbumRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.Repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            var result = await this.Repository.GetById(id);

            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Album model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await this.Repository.Save(model);
            return Created($"/{model.Id}", model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await this.Repository.GetById(id);
            await this.Repository.Remove(result);
            return NoContent();
        }
    }
}