using FlightBooking.Models;
using FlightBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBooking.Controllers
{
    public class FlightSearchController : Controller
    {
        // GET: FlightSearch
        public ActionResult Index()
        {
            var searchRequest = new SearchRequestViewModel();
            return View(searchRequest);
        }

        // POST: FlightSearch/Search
        [HttpPost]
        public async Task<ActionResult> Search(SearchRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_SearchForm", model);
            }

            var searchClient = new AirSearchClient();
            var searchRequest = new SearchRequest
            {
                DepartureDate = model.DepartureDate,
                Destination = model.Destination,
                Origin = model.Origin
            };

            var searchResult = await searchClient.AvailabilitySearchAsync(searchRequest);

            return PartialView("_SearchResults", searchResult.FlightOptions);
        }

        // GET: FlightSearch/Details
        public ActionResult Details(string flightNumber, string departureDateTime)
        {
            var model = new FlightDetailsViewModel
            {
                FlightNumber = flightNumber,
                DepartureDateTime = departureDateTime
            };

            return PartialView("_FlightDetails", model);
        }
    }
}
