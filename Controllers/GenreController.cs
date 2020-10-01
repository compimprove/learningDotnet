using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.DTOs;
using First.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace First.Controllers {
    [Route ("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase {

        private readonly ILogger<GenreController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenreController (ILogger<GenreController> logger, ApplicationDbContext context, IMapper mapper) {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GenreDTO>> GetGenres () {
            logger.LogInformation ("GetGenres");
            var genres = await context.Genres.AsNoTracking ().ToListAsync ();
            var genreDTOs = mapper.Map<List<GenreDTO>> (genres);
            return genreDTOs;
        }

        [HttpGet ("{Id:int}", Name = "getGenre")]
        public async Task<ActionResult<Genre>> GetGenre (int Id) {
            // var genre = await context.Genres.FirstOrDefaultAsync (x => x.Id == Id);
            // if (genre == null) {
            //     logger.LogWarning ($"Genre with id {Id} not found");
            //     return NotFound ();
            // } else {
            //     return genre;
            // }
            return new Genre () {
                Id = 5, Name = "Drama"
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] Genre genre) {
            context.Add (genre);
            await context.SaveChangesAsync ();
            return new CreatedAtRouteResult ("getGenre", new { Id = genre.Id }, genre);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> Put (int id, [FromBody] Genre genre) {
            genre.Id = id;
            context.Entry (genre).State = EntityState.Modified;
            await context.SaveChangesAsync ();
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> Delete (int id) {
            var exists = await context.Genres.AnyAsync (x => x.Id == id);
            if (!exists) {
                return NotFound ();
            } else {
                context.Remove (new Genre () { Id = id });
                await context.SaveChangesAsync ();
                return NoContent ();
            }
        }
    }
}