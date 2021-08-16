using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Models;
using Repositories.Repositories;
using Service.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
   public static class IServiceCollectionExtention
    {
        public static IServiceCollection AddDipendencies(this IServiceCollection collection)
        {
            collection.AddScoped<ICompanyRepo, CompanyRepo>();
            collection.AddDbContext<Flights>(opt => opt.UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = d:\Users\User\Documents\C#project\DB\DB\Flights.mdf;Integrated Security=True;Connect Timeout=30"));
            collection.AddAutoMapper(typeof(FlightsProFlight));
            return collection;
        }
    }
}
