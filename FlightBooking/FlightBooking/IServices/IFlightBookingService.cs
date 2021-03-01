using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace FlightBooking.IServices
{
    public interface IFlightBookingService
    {
        public Response AddFlight(FlightData flightDetail);
        public Response UpdateFlight(FlightData flightId);
        public Response DeleteFlight(int flightId);
        public IEnumerable<FlightData> GetAllFlight();
        public FlightData FlightGetById(int flightId);
        public Response FlightBookingByUser(FlightBookingDetail flightBookingDetails);
        public IEnumerable<FlightData> Availableflights();
    }
}
