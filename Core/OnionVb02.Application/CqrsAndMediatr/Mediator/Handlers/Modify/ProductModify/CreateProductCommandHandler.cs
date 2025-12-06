using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.ProductModify;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = new Product()
        {
            ProductName=request.ProductName,
            UnitPrice=request.UnitPrice,
            CategoryId=request.CategoryId,

        };
        await _repository.CreateAsync(product);
        return new CreateProductCommandResult
        {
            IsSuccess=true,
            Message = "Ürün eklendi"
        };
    }
}
