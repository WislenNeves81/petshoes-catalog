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
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAsync(Guid itemCatalogId)
        {
            var itemCatalog = await _shoeAppService
                                            .GetShoeByIdAsync(itemCatalogId)
                                            .ConfigureAwait(false);
            return Ok(itemCatalog);
        }
        //[HttpGet]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //public async Task<IActionResult> GetAllAsync() //COMO CRIAR MAIS DE UM GET NA ROTA?
        //{
        //    var itemCatalog = await _shoeAppService
        //                                    .GetAllAsync()
        //                                    .ConfigureAwait(false);

        //    return Ok(itemCatalog);
        //}
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

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutAsync(Guid itemCatalogId, [FromBody] ShoeInput shoeInput)
        {
            var itemCatalog = await _shoeAppService
                                            .UpdateAsync(itemCatalogId, shoeInput)
                                            .ConfigureAwait(false);

            return Ok(itemCatalog);
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteAsync(Guid itemCatalogId) 
        {
            await _shoeAppService
                        .DeleteAsync(itemCatalogId)
                        .ConfigureAwait(false);

            return Ok();
        }
    }
}