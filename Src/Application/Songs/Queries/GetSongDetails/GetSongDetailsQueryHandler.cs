using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;

namespace Player.Application.Songs.Queries.GetSongDetails
{
    public class GetSongDetailsQueryHandler : IRequestHandler<GetSongDetailsQuery, Song>
    {
        private readonly IPlayerDbContext _playerDbContext;

        public GetSongDetailsQueryHandler(IPlayerDbContext playerDbContext)
        {
            _playerDbContext = playerDbContext;
        }

        public async Task<Song> Handle(GetSongDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _playerDbContext.Songs.FindAsync(request.Id);
        }
    }
}
