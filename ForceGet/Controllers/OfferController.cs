using Business.Interfaces;
using Core.GlobalModels.Offer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForceGet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost]
        [Route("SaveOffer")]
        public async Task<IActionResult> SaveOffer([FromBody] OfferModel request)
        {

            var serviceResult =  await _offerService.SaveOffer(request);

            return Ok(serviceResult);
        }

        [HttpGet]
        [Route("GetOfferList")]
        public ActionResult GetOfferList()
        {

            var serviceResult = _offerService.GetOfferList();

            return Ok(serviceResult);
        }

        [HttpGet]
        [Route("GetOfferDetails")]
        public ActionResult GetOfferDetails(int id)
        {

            var serviceResult = _offerService.GetOfferDetails(id);
            return Ok(serviceResult);
        }
        


    }
}
