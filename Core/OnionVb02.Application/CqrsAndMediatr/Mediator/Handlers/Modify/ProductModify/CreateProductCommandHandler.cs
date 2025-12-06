using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.ProductModify;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
{
    private readonly IProductRepository _repository;
    private readonly ICustomMapper<CreateProductCommand, Product> _mapper;

    public CreateProductCommandHandler(
        IProductRepository repository,
        ICustomMapper<CreateProductCommand, Product> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = _mapper.Map(request);
        await _repository.CreateAsync(product);
        
        return new CreateProductCommandResult
        {
            IsSuccess = true,
            Message = "Ürün eklendi"
        };
    }
}
