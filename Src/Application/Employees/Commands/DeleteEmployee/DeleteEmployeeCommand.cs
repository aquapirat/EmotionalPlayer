﻿using MediatR;
using Player.Application.Common.Exceptions;
using Player.Application.Common.Interfaces;
using Player.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Player.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
        {
            private readonly IPlayerDbContext _context;
            private readonly IUserManager _userManager;
            private readonly ICurrentUserService _currentUser;

            public DeleteEmployeeCommandHandler(IPlayerDbContext context, IUserManager userManager, ICurrentUserService currentUser)
            {
                _context = context;
                _userManager = userManager;
                _currentUser = currentUser;
            }

            public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Employees
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employee), request.Id);
                }

                if (entity.UserId == _currentUser.UserId)
                {
                    throw new BadRequestException("Employees cannot delete their own account.");
                }

                if (entity.UserId != null)
                {
                    await _userManager.DeleteUserAsync(entity.UserId);
                }

                // TODO: Update this logic, this will only work if the employee has no associated territories or orders.Emp

                _context.Employees.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
