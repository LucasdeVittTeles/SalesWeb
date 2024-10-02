using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Server.Services;
using SalesWeb.Server.DTOs;

namespace SalesWeb.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {

        private readonly ISellerService _sellerService;

        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<SellerDto>>> GetAllSellers()
        {
            var sellers = await _sellerService.FindAllAsync();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SellerDto>> GetSeller(int id)
        {
            var product = await _sellerService.FindByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> PostSeller(SellerDto sellerDto)
        {
            await _sellerService.InsertAsync(sellerDto);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteSeller(int id)
        {

            var seller = await _sellerService.FindByIdAsync(id);

            if (seller == null)
            {
                return NotFound();
            }

            await _sellerService.RemoveAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSeller(int id, [FromBody] SellerDto sellerDto)
        {

            if (id != sellerDto.Id)
            {
                return BadRequest();
            }

            var existingSeller = await _sellerService.FindByIdAsync(id);
            if (existingSeller == null)
            {
                return NotFound();
            }

            await _sellerService.UpdateAsync(sellerDto);
            return NoContent();
        }
    }
}
