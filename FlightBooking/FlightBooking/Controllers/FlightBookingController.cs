using DAL.Entities;
using FlightBooking.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightBookingController : ControllerBase
    {
        private readonly IFlightBookingService _flightBooking;

        public FlightBookingController(IFlightBookingService flightBooking)
        {
            _flightBooking = flightBooking;
        }


        [HttpGet]
        [Route("getallflight")]
        public IEnumerable<FlightData> GetAllFlight()
        {
            var allFlightDetails = _flightBooking.GetAllFlight();

            return allFlightDetails;
        }

        [HttpGet]
        [Route("flightgetbyid")]
        public FlightData FlightGetById(int flightId)
        {
            var getFlightDetailsById = _flightBooking.FlightGetById(flightId);
            return getFlightDetailsById;
        }


        [HttpPost]
        [Route("addflight")]
        public IActionResult AddFlight([FromBody] FlightData flightDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _flightBooking.AddFlight(flightDetail);

            return Ok(result);
        }


        [HttpPut]
        [Route("updateflight")]
        public IActionResult UpdateFlight([FromBody] FlightData flightDetail)
        {
            var result = _flightBooking.UpdateFlight(flightDetail);

            return Ok(result);
        }


        [HttpDelete]
        [Route("deleteflight")]
        public IActionResult DeleteFlight(int flightId)
        {
            var result = _flightBooking.DeleteFlight(flightId);
            return Ok(result);
        }

        [HttpPost]
        [Route("flightbookingbyuesr")]
        public IActionResult FlightBookingByUser([FromBody] FlightBookingDetail flightBookingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _flightBooking.FlightBookingByUser(flightBookingDetails);

            return Ok(result);
        }


        [HttpGet]
        [Authorize(Roles = UserRoles.User)]
        [Route("availableflights")]
        public IEnumerable<FlightData> Availableflights()
        {
            var allAvailableFlights = _flightBooking.Availableflights();

            return allAvailableFlights;
        }

    }
}
