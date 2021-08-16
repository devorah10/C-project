
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
   public interface ICompanyRepo
    {
        void Update();
        int Add(Company company);
        List<Company> GetCompanyFlight();
         List<Flight> GetFlightByCompany(int id);
         List<Flight> GetFlightBydestination(int id);
        List<Flight> GetFlightByDate(DateTime time, string id);
        string Delete(string airport);
    }
}
