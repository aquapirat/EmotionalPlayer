using MediatR;
using Microsoft.AspNetCore.Http;

namespace Player.Application.Songs.Commands.Create
{
    public class CreateSongCommand : IRequest
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Length { get; set; }
        public IFormFile AudioFile { get; set; }
    }
}
