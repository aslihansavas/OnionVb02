using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.CategoryModify;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
{
    private readonly ICategoryRepository _repository;
    private readonly ICustomMapper<CreateCategoryCommand, Category> _mapper;

    public CreateCategoryCommandHandler(
        ICategoryRepository repository,
        ICustomMapper<CreateCategoryCommand, Category> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = _mapper.Map(request);
        await _repository.CreateAsync(category);
        
        return new CreateCategoryCommandResult
        {
            IsSuccess = true,
            Message = $"{category.CategoryName} Kategorisi Oluşturuldu."
        };
    }
}
