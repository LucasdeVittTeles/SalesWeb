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

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
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
    }
}
