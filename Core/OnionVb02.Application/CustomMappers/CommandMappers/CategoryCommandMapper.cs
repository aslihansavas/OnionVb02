using System;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CustomMappers.CommandMappers;

public class CreateCategoryCommandMapper : ICustomMapper<CreateCategoryCommand, Category>
{
    public Category Map(CreateCategoryCommand source)
    {
        return new Category()
        {
            CategoryName=source.CategoryName,
            CreatedDate=DateTime.Now,
            Status=Domain.Enums.DataStatus.Inserted,
            Description=source.Description
            
        };
    }

    public List<Category> MapList(List<CreateCategoryCommand> sources)
    {
        return sources.Select(x=>Map(x)).ToList();
    }
}

public class UpdateCategoryCommandMapper : ICustomMapper<UpdateCategoryCommand, Category>
{
    public Category Map(UpdateCategoryCommand source)
    {
         return new Category
        {
            Id = source.Id,
            CategoryName = source.CategoryName,
            Description=source.Description,
            UpdatedDate = DateTime.Now,
            Status = Domain.Enums.DataStatus.Updated
        };
    }

    public List<Category> MapList(List<UpdateCategoryCommand> sources)
    {
        return sources.Select(x=>Map(x)).ToList();
    }
}
public class RemoveCategoryCommandMapper : ICustomMapper<RemoveCategoryCommand, Category>
{
    public Category Map(RemoveCategoryCommand source)
    {
        return new Category
        {
            Id = source.Id,
            Status = Domain.Enums.DataStatus.Deleted
        };
    }

    public List<Category> MapList(List<RemoveCategoryCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}