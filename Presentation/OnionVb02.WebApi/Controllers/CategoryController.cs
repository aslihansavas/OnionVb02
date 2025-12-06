using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;


namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            List<GetCategoryQueryResult> appUsers = await _mediator.Send(new GetCategoryQuery());
            return Ok(appUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            GetCategoryByIdResult value = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            CreateCategoryCommandResult result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            UpdateCategoryCommandResult result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            RemoveCategoryCommandResult result = await _mediator.Send(new RemoveCategoryCommand(id));
            return Ok(result);
        }


    }
}
