using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.CategoryModify;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResult>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _repository.GetByIdAsync(request.Id);
        category.CategoryName = request.CategoryName;
        category.Description= request.Description;
        category.UpdatedDate=DateTime.Now;
        category.Status=Domain.Enums.DataStatus.Updated;
        await _repository.SaveChangesAsync();
        return new UpdateCategoryCommandResult
        {
            IsSuccess=true,
            Message=$"{category.Id} id'li Category Güncellendi."
        };
    }
}
