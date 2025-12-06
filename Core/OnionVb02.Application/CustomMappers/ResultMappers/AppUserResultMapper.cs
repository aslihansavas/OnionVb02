using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CustomMappers.ResultMappers;

public class AppUserToResultMapper : ICustomMapper<AppUser, GetAppUserQueryResult>
{
    public GetAppUserQueryResult Map(AppUser source)
    {
        return new GetAppUserQueryResult
        {
            Id = source.Id,
            UserName = source.UserName,
            Password = source.Password
        };
    }

    public List<GetAppUserQueryResult> MapList(List<AppUser> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class AppUserToByIdResultMapper : ICustomMapper<AppUser, GetAppUserByIdQueryResult>
{
    public GetAppUserByIdQueryResult Map(AppUser source)
    {
        return new GetAppUserByIdQueryResult
        {
            Id = source.Id,
            UserName = source.UserName,
            Password = source.Password
        };
    }

    public List<GetAppUserByIdQueryResult> MapList(List<AppUser> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

