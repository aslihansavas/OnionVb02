using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CustomMappers.ResultMappers;

public class AppUserProfileToResultMapper : ICustomMapper<AppUserProfile, GetAppUserProfileQueryResult>
{
    public GetAppUserProfileQueryResult Map(AppUserProfile source)
    {
        return new GetAppUserProfileQueryResult
        {
            Id = source.Id,
            FirstName = source.FirstName,
            LastName = source.LastName
        };
    }

    public List<GetAppUserProfileQueryResult> MapList(List<AppUserProfile> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class AppUserProfileToByIdResultMapper : ICustomMapper<AppUserProfile, GetAppUserProfileByIdQueryResult>
{
    public GetAppUserProfileByIdQueryResult Map(AppUserProfile source)
    {
        return new GetAppUserProfileByIdQueryResult
        {
            Id = source.Id,
            FirstName = source.FirstName,
            LastName = source.LastName
        };
    }

    public List<GetAppUserProfileByIdQueryResult> MapList(List<AppUserProfile> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

