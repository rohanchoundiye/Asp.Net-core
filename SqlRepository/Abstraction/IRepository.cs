using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace SqlRepository.Abstraction
{
    public interface IRepository
    {
        public Response AddFlight(FlightData flightDetail);
        public Response UpdateFlight(FlightData flightDetail);
        public Response DeleteFlight(int flightId);
        public IEnumerable<FlightData> GetAllFlight();
        public FlightData FlightGetById(int flightId);
        public Response FlightBookingByUser(FlightBookingDetail flightBookingDetails);
    }
}
