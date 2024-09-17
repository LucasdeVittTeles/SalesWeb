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
        public ActionResult<ICollection<Seller>> GetAllSellers()
        {
            var sellers = _sellerService.FindAll();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public ActionResult<Seller> GetSeller(int id)
        {
            var product = _sellerService.GetSellerById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostSeller(Seller seller)
        {
            _sellerService.Insert(seller);
            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteSeller(int id)
        {

            var seller = _sellerService.GetSellerById(id);

            if (seller == null)
            {
                return NotFound();
            }

            _sellerService.RemoveSeller(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult PutSeller(int id, [FromBody] Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            var existingSeller = _sellerService.GetSellerById(id);
            if (existingSeller == null)
            {
                return NotFound();
            }

            _sellerService.UpdateSeller(seller);
            return NoContent();
        }
    }
}
