using AutoMapper;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using SqlRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;

namespace SqlRepository.Implementation
{
    public class Repository : IRepository
    {
        private readonly MyDatabaseContext _context;
        private readonly IMapper _mapper;

        public Repository(MyDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Response AddFlight(FlightData flightDetail)
        {
            if (flightDetail != null) 
            {
                var data = _mapper.Map<FlightData>(flightDetail);
                _context.Add(data);
                _context.SaveChanges();

                return new Response { Status = "Success", Message = "Data added Successfully" };
            }
            return new Response { Status = "Error"};
        }

        public Response UpdateFlight(FlightData flightDetail)
        {
            if (flightDetail != null)
            {
                var data = _mapper.Map<FlightData>(flightDetail);
                _context.Entry<FlightData>(data).State = EntityState.Modified;
                _context.SaveChanges();
                return new Response { Status = "Success", Message = "Data Updated Successfully" };
            }
            return new Response { Status = "Error"};
        }

        public Response DeleteFlight(int flightId)
        {
            if (flightId != null)
            {
                var dataToDelete = _context.Set<FlightData>().Find(flightId);
                _context.Remove(dataToDelete);
                _context.SaveChanges();
                return new Response { Status = "Success", Message = "Data deleted Successfully" };
            }
            return new Response { Status = "Error" };

        }

        public IEnumerable<FlightData> GetAllFlight()
        {
            var result = _context.Set<FlightData>().ToList();
            List<FlightData> flightDetails = _mapper.Map<List<FlightData>>(result);

            return flightDetails;
        }
        public FlightData FlightGetById(int flightId)
        {
            var getDataById = _context.Set<FlightData>().Find(flightId);
            var result = _mapper.Map<FlightData>(getDataById);
            return result;
        }

        public Response FlightBookingByUser(FlightBookingDetail flightBookingDetails)
        {
            if (flightBookingDetails != null)
            {
                var userDetails = _mapper.Map<FlightBookingDetail>(flightBookingDetails);
                _context.Add(userDetails);
                _context.SaveChanges();
                return new Response { Status = "Success", Message = "Flight Booked" };
            }
            return new Response { Status = "Error" };
        }


    }
}
