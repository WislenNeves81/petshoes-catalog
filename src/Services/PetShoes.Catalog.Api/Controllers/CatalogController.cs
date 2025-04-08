using Microsoft.AspNetCore.Mvc;
using PetShoes.Catalog.Application.AppShoe.Input;
using PetShoes.Catalog.Application.AppShoe.Interface;

namespace PetShoes.Catalog.Api.Controllers
{
    [Route("petshoes/api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IShoeAppService _shoeAppService;

        public CatalogController(IShoeAppService shoeAppService)
        {
            _shoeAppService = shoeAppService;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] ShoeInput shoeInput)
        {
            var itemCatalog = await _shoeAppService
                                        .InsertAsync(shoeInput)
                                        .ConfigureAwait(false);

            return Ok(itemCatalog);
        }
    }
}