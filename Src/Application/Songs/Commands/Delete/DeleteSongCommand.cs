using MediatR;

namespace Player.Application.Songs.Commands.Delete
{
    public class DeleteSongCommand : IRequest
    {
        public int Id { get; set; }
    }
}
