using AutoMapper;
using Repositories.Models;
using Service.common;
using System;
using System.Collections.Generic;
using System.Text;


namespace Service.Profiles
{
    public class FlightsProFlight:Profile
    {
        public FlightsProFlight()
        {
          CreateMap<Flight,FlightVM>().ReverseMap().ForPath(f => f.Id, o => o.Ignore());


        }

    }
}
