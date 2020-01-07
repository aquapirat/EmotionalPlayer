using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Player.Application.Songs.Commands.Create;
using Player.Application.Songs.Commands.Delete;
using Player.Application.Songs.Commands.Update;
using Player.Application.Songs.Queries.GetSongDetails;

namespace Player.WebUI.Controllers
{
    [ValidateAntiForgeryToken]
    public class SongController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            return Ok(Mediator.Send(new GetSongDetailsQuery { Id = id }));
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