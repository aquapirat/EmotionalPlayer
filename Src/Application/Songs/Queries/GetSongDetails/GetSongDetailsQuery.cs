using MediatR;
using Player.Domain.Entities;

namespace Player.Application.Songs.Queries.GetSongDetails
{
    public class GetSongDetailsQuery : IRequest<Song>
    {
        public int Id { get; set; }
    }
}
