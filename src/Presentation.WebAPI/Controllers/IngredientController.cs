using Application.DTO;
using Domain.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController(IReadService<IngredientReponse> ingredientService) : ControllerBase
    {
        private readonly IReadService<IngredientReponse> ingredientService = ingredientService;

        [HttpGet]
        [ResponseCache(Duration = 300)]
        [SwaggerResponse((int)HttpStatusCode.OK, "Success. Ingredient list is successfully returned.", typeof(IEnumerable<IngredientReponse>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request", typeof(ProblemDetails))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Internal Server Error", typeof(ProblemDetails))]
        public async Task<IActionResult> Get()
        {
            var elixirs = await this.ingredientService.GetAllAsync();

            return this.Ok(elixirs);
        }
    }
}
