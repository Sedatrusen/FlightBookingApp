using System;
using System.ComponentModel.DataAnnotations;

namespace FlightBooking.ViewModels
{
    public class SearchRequestViewModel
    {
        [Required(ErrorMessage = "Origin is required.")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
    }
}
