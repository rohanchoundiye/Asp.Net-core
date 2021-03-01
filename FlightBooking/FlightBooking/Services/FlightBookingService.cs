using AutoMapper;
using DAL;
using DAL.Entities;
using FlightBooking.IServices;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace FlightBooking.Services
{
    public class FlightBookingService : IFlightBookingService
    {
        private readonly MyDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public FlightBookingService(MyDatabaseContext context, IMapper mapper, IRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        public Response AddFlight(FlightData flightDetail)
        {
            var result = _repository.AddFlight(flightDetail);
            return result;
        }

        public Response UpdateFlight(FlightData flightDetail)
        {
            var result =  _repository.UpdateFlight(flightDetail);
            return result;
        }

        public Response DeleteFlight(int flightId)
        {
            var result = _repository.DeleteFlight(flightId);
            return result;
        }

        public IEnumerable<FlightData> GetAllFlight()
        {
            var result = _repository.GetAllFlight();
            return result;
        }
        public FlightData FlightGetById(int flightId)
        {
            var result = _repository.FlightGetById(flightId);
            return result;
        }

        public Response FlightBookingByUser(FlightBookingDetail flightBookingDetails)
        {
            var allFlightDetails = _repository.GetAllFlight();

            var userDate = flightBookingDetails.DateOfJourney.ToString();

            foreach (var item in allFlightDetails)
            {
                if (item.FlightDate == userDate && item.Status != "Booked")
                {
                    item.Status = "Booked";
                    _repository.UpdateFlight(item);

                    var result = _repository.FlightBookingByUser(flightBookingDetails);

                    return result;
                }
            }
            return new Response { Status = "Error", Message = "Flight not Booked" };
        }

        public IEnumerable<FlightData> Availableflights()
        {
            List<FlightData> allAvailableFlights = new List<FlightData>();

            var allFlights = _repository.GetAllFlight();

            foreach (var item in allFlights)
            {
                if (item.Status != "Booked")
                {
                    allAvailableFlights.Add(item);
                }
            }

            return allAvailableFlights;
        }

    }
}
