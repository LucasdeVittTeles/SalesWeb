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
            var sellers = await _sellerService.GetAllAsync();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SellerDto>> GetSeller(int id)
        {
            var product = await _sellerService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> PostSeller(SellerDto sellerDto)
        {
            await _sellerService.AddAsync(sellerDto);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteSeller(int id)
        {

            var seller = await _sellerService.GetByIdAsync(id);

            if (seller == null)
            {
                return NotFound();
            }

            await _sellerService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSeller(int id, [FromBody] SellerDto sellerDto)
        {
            await _sellerService.UpdateAsync(id, sellerDto);
            return Ok();
        }
    }
}
