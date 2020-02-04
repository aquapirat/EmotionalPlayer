using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Player.Application.Songs.Commands.Create;
using Player.Application.Songs.Commands.Delete;
using Player.Application.Songs.Commands.Update;
using Player.Application.Songs.Queries.GetSongDetails;
using Player.Domain.Entities;

namespace Player.WebUI.Controllers
{
    public class SongController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Song>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSongDetailsQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateSongCommand command)
        {
            var id = await Mediator.Send(command);

            return Created((string)null, id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(UpdateSongCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSongCommand { Id = id }) ;

            return NoContent();
        }
    }
}