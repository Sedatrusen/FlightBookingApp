
using FlightBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace FlightBooking.Controllers
{
    public class FlightSearchController : Controller
    {
        // GET: FlightSearch
        public ActionResult Index()
        {
            return View();
        }

        // POST: FlightSearch/Search
        [HttpPost]
        public async Task<ActionResult> Search(SearchRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var searchClient = new AirSearchClient();
            var searchRequest = new SearchRequest
            {
                DepartureDate = model.DepartureDate,
                Destination = model.Destination,
                Origin = model.Origin
            };

            var searchResult = await searchClient.AvailabilitySearchAsync(searchRequest);

            return View("SearchResults", searchResult.FlightOptions);
        }
    }  
}
