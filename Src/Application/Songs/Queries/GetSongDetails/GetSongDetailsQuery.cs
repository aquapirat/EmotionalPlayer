using MediatR;

namespace Player.Application.Songs.Queries.GetSongDetails
{
    public class GetSongDetailsQuery : IRequest
    {
        public int Id { get; set; }
    }
}
