using Service.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ICompanyService
    {
       List<companyVM> GetCompanyByFlight();
         List<FlightVM> GetFlightByCompany(int id); 
         List<FlightVM> GetFlightBydestination(int id);
        List<FlightVM> GetFlightByDate(DateTime time, string id);
        int Add(companyVM cmv);
        string Delete(string airport);
    }
        
}
