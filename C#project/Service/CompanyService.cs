using AutoMapper;
using Repositories.Models;
using Repositories.Repositories;
using Service.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepo cr;
        IMapper mapper;

       

        public CompanyService(ICompanyRepo cr,IMapper mapper )
        {
            this.cr = cr;
            this.mapper = mapper;
        }

       
        public List<companyVM> GetCompanyByFlight()
        {
            List<Company> listCom = cr.GetCompanyFlight();
            List<companyVM> listConmVm = new List<companyVM>();
            foreach (var item in listCom)
            {
                listConmVm.Add(mapper.Map<companyVM>(item));
            }

            return listConmVm;
        }
        public List<FlightVM> GetFlightByCompany(int id)
        {
            List<Flight> listFlight = cr.GetFlightByCompany(id);
            List<FlightVM> listFlightVM = new List<FlightVM>();
            foreach (var item in listFlight)
            {
                listFlightVM.Add(mapper.Map<FlightVM>(item));
            }
            return listFlightVM;
        }

        public List<FlightVM> GetFlightByDate(DateTime time, string id)
        {
            List<Flight> listFlight = cr.GetFlightByDate(time, id);
            List<FlightVM> listFlightVM = new List<FlightVM>();
            foreach (var item in listFlight)
            {
                listFlightVM.Add(mapper.Map<FlightVM>(item));
            }
            return listFlightVM;
        }

        public List<FlightVM> GetFlightBydestination(int id)
        {
            List<Flight> listFlight = cr.GetFlightBydestination(id);
            List<FlightVM> listFlightVM = new List<FlightVM>();
            foreach (var item in listFlight)
            {
                listFlightVM.Add(mapper.Map<FlightVM>(item));
            }
            return listFlightVM;
        }
        public int Add(companyVM cmv)
        {
            return cr.Add(mapper.Map<Company>(cmv));
        }

        public string Delete(string airport)
        {
            return cr.Delete(airport);
        }


    }

}

