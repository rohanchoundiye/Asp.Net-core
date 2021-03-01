using FlightBooking.IServices;
using FlightBooking.Services;
using Microsoft.Extensions.DependencyInjection;
using SqlRepository.Abstraction;
using SqlRepository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Configuration
{
    public static class ApplicationSetup
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            serviceCollection.AddScoped<IFlightBookingService, FlightBookingService>();
            serviceCollection.AddScoped<IRepository, Repository>();
        }
    }
}
