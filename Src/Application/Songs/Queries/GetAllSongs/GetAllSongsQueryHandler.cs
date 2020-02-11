using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;

namespace Player.Application.Songs.Queries.GetAllSongs
{
    public class GetAllSongsQueryHandler : IRequestHandler<GetAllSongsQuery, IEnumerable<Song>>
    {
        private readonly IPlayerDbContext _playerDbContext;

        public GetAllSongsQueryHandler(IPlayerDbContext playerDbContext)
        {
            _playerDbContext = playerDbContext;
        }

        public Task<IEnumerable<Song>> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_playerDbContext.Songs.OrderBy(s => s.Id).AsEnumerable());
        }
    }
}
