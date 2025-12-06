using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CustomMappers.ResultMappers;

public class CategoryToResultMapper : ICustomMapper<Category, GetCategoryQueryResult>
{
    public GetCategoryQueryResult Map(Category source)
    {
        return new GetCategoryQueryResult
        {
            Id = source.Id,
            CategoryName = source.CategoryName,
            Description = source.Description
        };
    }

    public List<GetCategoryQueryResult> MapList(List<Category> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class CategoryToByIdResultMapper : ICustomMapper<Category, GetCategoryByIdResult>
{
    public GetCategoryByIdResult Map(Category source)
    {
        return new GetCategoryByIdResult
        {
            Id = source.Id,
            CategoryName = source.CategoryName,
            Description = source.Description
        };
    }

    public List<GetCategoryByIdResult> MapList(List<Category> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

