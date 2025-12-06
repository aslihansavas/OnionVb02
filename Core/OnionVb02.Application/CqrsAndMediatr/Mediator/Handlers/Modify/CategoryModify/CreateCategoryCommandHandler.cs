using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.CategoryModify;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new Category()
        {
            CategoryName=request.CategoryName,
            Description=request.Description,
            CreatedDate=DateTime.Now,
            Status=Domain.Enums.DataStatus.Inserted
        };
        await _repository.CreateAsync(category);
        return new CreateCategoryCommandResult
        {
            IsSuccess=true,
            Message = $"{category.CategoryName} Kategorisi Oluşturuldu."
        };
    }
}
