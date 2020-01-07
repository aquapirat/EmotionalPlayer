using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;

// TODO: Add (implement) IBlobStorageUploader  to upload songs to actual blob storage.
namespace Player.Application.Songs.Commands.Create
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand>
    {
        private readonly IPlayerDbContext _playerDbContext;

        public CreateSongCommandHandler(IPlayerDbContext playerDbContext)
        {
            _playerDbContext = playerDbContext;
        }

        public async Task<Unit> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var newSong = new Song
            {
                Name = request.Name,
                Length = request.Length,
            };

            _playerDbContext.Songs.Add(newSong);
            await _playerDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
