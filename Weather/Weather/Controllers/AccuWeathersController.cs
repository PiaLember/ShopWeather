using Microsoft.AspNetCore.Mvc;
using Nancy.Extensions;
using Weather.Dto;
using Weather.Models;
using Weather.ServiceInterface;

namespace Weather.Controllers
{
    public class AccuWeathersController : Controller
    {
        private readonly IWeatherForecastServices _accuWeatherServices;

        public AccuWeathersController
            (IWeatherForecastServices accuWeathertServices)
        {
            _accuWeatherServices = accuWeathertServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(IndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeathers", new { city = model.City });
            }
            return View(model);
        }

        public async Task<IActionResult> City(string city)
        {
            AccuWeatherLocationResultDto dto = new();

            dto.City = city;

            await _accuWeatherServices.AccuWeatherLocationResult(dto);
            

            return View(dto);
        }
    }
}
