using Application.DTO;
using Domain.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElixirController(IReadByService<ElixirReponse> elixirService) : ControllerBase
    {
        private readonly IReadByService<ElixirReponse> elixirService = elixirService;

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, "Success. Elixir list is successfully returned.", typeof(IEnumerable<ElixirReponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request", typeof(ProblemDetails))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Internal Server Error", typeof(ProblemDetails))]
        public async Task<IActionResult> Post([FromBody] IEnumerable<string> ingredientsName)
        {
            var elixirs = await this.elixirService.GetByAsync(ingredientsName);

            return this.Ok(elixirs);
        }
    }
}
