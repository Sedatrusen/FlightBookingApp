using FlightBooking.Models;
using Microsoft.AspNetCore.Mvc;


namespace FlightBooking.Controllers
{
    public class FlightDetailsController : Controller
    {
        // GET: FlightDetails/Details/5
        public ActionResult Details(string flightNumber, string departureDateTime)
        {
            // FlightDetails view'ine gerekli verileri aktar
            var model = new FlightDetailsViewModel
            {
                FlightNumber = flightNumber,
                DepartureDateTime = departureDateTime
            };
            return View(model);
        }
    }
}
