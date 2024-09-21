using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Server.Models;
using SalesWeb.Server.Services;

namespace SalesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;


        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Seller>>> GetAllSellers()
        {
            var sellers = await _sellerService.FindAllAsync();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetSeller(int id)
        {
            var product = await _sellerService.FindByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PostSeller(Seller seller)
        {
            await _sellerService.InsertAsync(seller);
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
        public async Task<ActionResult> PutSeller(int id, [FromBody] Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            var existingSeller = await _sellerService.FindByIdAsync(id);
            if (existingSeller == null)
            {
                return NotFound();
            }

            await _sellerService.UpdateAsync(seller);
            return NoContent();
        }
    }
}
