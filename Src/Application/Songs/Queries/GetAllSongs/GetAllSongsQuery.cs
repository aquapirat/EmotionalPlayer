using System.Collections.Generic;
using MediatR;
using Player.Domain.Entities;

namespace Player.Application.Songs.Queries.GetAllSongs
{
    public class GetAllSongsQuery : IRequest<IEnumerable<Song>>
    {
    }
}
