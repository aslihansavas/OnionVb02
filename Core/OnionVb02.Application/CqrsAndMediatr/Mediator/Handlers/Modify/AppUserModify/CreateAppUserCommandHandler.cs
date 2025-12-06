using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand,CreateAppUserCommandResult>
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateAppUserCommandResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
             await _repository.CreateAsync(new AppUser
            {
                 CreatedDate = DateTime.Now,
                 Status =Domain.Enums.DataStatus.Inserted,
                 UserName = request.UserName,
                 Password = request.Password
            });
            return new CreateAppUserCommandResult
            {
                IsSuccess=true,
                Message = "Kullanıcı Oluşturuldu"
            };
        }
    }
}
