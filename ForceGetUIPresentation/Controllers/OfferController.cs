using ForceGetUIPresentation.Models;
using ForceGetUIPresentation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
namespace ForceGetUIPresentation.Controllers
{
    public class OfferController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        public IActionResult AddOffer()
        {
            return View(new OfferModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddOffer(OfferModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _offerService.SaveOffer(model);

                if(response == StatusCodes.Status200OK)
                    return RedirectToAction("Success");
                else
                {
                    return View(model);
                }
            }
            else
            {
                // Form verileri geçerli değilse hatalarla birlikte form tekrar gösterilir
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> OfferList()
        {
            var response = await _offerService.GetOfferList();
            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> OfferByFilter(OfferModel model)
        {
            //var response = await _offerService.GetOfferById(model.Id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
