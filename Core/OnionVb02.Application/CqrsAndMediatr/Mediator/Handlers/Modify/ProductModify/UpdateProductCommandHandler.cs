using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.ProductModify;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResult>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product value = await _repository.GetByIdAsync(request.Id);
        value.CategoryId=request.CategoryId;
        value.ProductName=request.ProductName;
        value.UnitPrice=request.UnitPrice;
        value.UpdatedDate=DateTime.Now;
        value.Status=Domain.Enums.DataStatus.Updated;
        await _repository.SaveChangesAsync();
        return new UpdateProductCommandResult
        {
            IsSuccess=true,
            Message = "Ürün Güncellendi."
        };
    }
}
