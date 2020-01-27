using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Player.Application.Common.Interfaces;
using Player.Application.Common.Interfaces.BlobStorage;
using Player.Domain.Entities;

// TODO: Add (implement) IBlobStorageUploader  to upload songs to actual blob storage.
namespace Player.Application.Songs.Commands.Create
{
    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand>
    {
        private readonly IPlayerDbContext _playerDbContext;
        private readonly IBlobStorageService _blobStorageService;

        public CreateSongCommandHandler(IPlayerDbContext playerDbContext,
            IBlobStorageService blobStorageService)
        {
            _playerDbContext = playerDbContext;
            _blobStorageService = blobStorageService;
        }

        public async Task<Unit> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var newSong = new Song
            {
                Name = request.Name,
                Length = request.Length,
            };

            using(var stream = request.AudioFile.OpenReadStream())
            {
                _blobStorageService.UploadBlob(request.Name, stream);
            }

            _playerDbContext.Songs.Add(newSong);
            await _playerDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
