using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CustomMappers.CommandMappers;

public class CreateAppUserProfileCommandMapper : ICustomMapper<CreateAppUserProfileCommand, AppUserProfile>
{
    public AppUserProfile Map(CreateAppUserProfileCommand source)
    {
        return new AppUserProfile
        {
            FirstName = source.FirstName,
            LastName = source.LastName,
            AppUserId = source.AppUserId,
            CreatedDate = DateTime.Now,
            Status = DataStatus.Inserted
        };
    }

    public List<AppUserProfile> MapList(List<CreateAppUserProfileCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class UpdateAppUserProfileCommandMapper : ICustomMapper<UpdateAppUserProfileCommand, AppUserProfile>
{
    public AppUserProfile Map(UpdateAppUserProfileCommand source)
    {
        return new AppUserProfile
        {
            Id = source.Id,
            FirstName = source.FirstName,
            LastName = source.LastName,
            UpdatedDate = DateTime.Now,
            Status = DataStatus.Updated
        };
    }

    public List<AppUserProfile> MapList(List<UpdateAppUserProfileCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class RemoveAppUserProfileCommandMapper : ICustomMapper<RemoveAppUserProfileCommand, AppUserProfile>
{
    public AppUserProfile Map(RemoveAppUserProfileCommand source)
    {
        return new AppUserProfile
        {
            Id = source.Id,
            Status = DataStatus.Deleted
        };
    }

    public List<AppUserProfile> MapList(List<RemoveAppUserProfileCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

