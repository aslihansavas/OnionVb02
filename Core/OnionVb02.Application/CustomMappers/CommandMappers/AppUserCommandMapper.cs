using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CustomMappers.CommandMappers;

public class CreateAppUserCommandMapper : ICustomMapper<CreateAppUserCommand, AppUser>
{
    public AppUser Map(CreateAppUserCommand source)
    {
        return new AppUser
        {
            UserName = source.UserName,
            Password = source.Password,
            CreatedDate = DateTime.Now,
            Status = DataStatus.Inserted
        };
    }

    public List<AppUser> MapList(List<CreateAppUserCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class UpdateAppUserCommandMapper : ICustomMapper<UpdateAppUserCommand, AppUser>
{
    public AppUser Map(UpdateAppUserCommand source)
    {
        return new AppUser
        {
            Id = source.Id,
            UserName = source.UserName,
            Password = source.Password,
            UpdatedDate = DateTime.Now,
            Status = DataStatus.Updated
        };
    }

    public List<AppUser> MapList(List<UpdateAppUserCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class RemoveAppUserCommandMapper : ICustomMapper<RemoveAppUserCommand, AppUser>
{
    public AppUser Map(RemoveAppUserCommand source)
    {
        return new AppUser
        {
            Id = source.Id,
            Status = DataStatus.Deleted
        };
    }

    public List<AppUser> MapList(List<RemoveAppUserCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

