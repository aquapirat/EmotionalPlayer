using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Player.Application.Songs.Commands.Update
{
    public class UpdateSongCommand : IRequest
    {
        public int Id { get; set; }
    }
}
