using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class CompanyRepo : ICompanyRepo
    
    {
        Flights contaxt=new Flights();



        
        public int Add(Company company)
        {
            var check = contaxt.Company.Any(c => c.Id == company.Id && c.Description == company.Description);
           if(!check)
            {
                var result = contaxt.Company.Add(company);
                contaxt.SaveChanges();
                return result.Entity.Id;
            }
            return -1;
        }

        public List<Company> GetCompanyFlight()
        {
            return contaxt.Company.Where(c => c.Flight.Count() != 0).ToList();
            // var isExists = context.Book.Any(b => b.Name == book.Name && b.AuthorId == book.AuthorId);

        }
        public List<Flight> GetFlightByCompany(int id)
        {
           var x= contaxt.Flight.Where(c => c.Id== id).ToList();
            return x;
        }

        public List<Flight> GetFlightByDate(DateTime time, string id)
        {
            Airport a = contaxt.Airport.Where(ap => ap.Description == id).FirstOrDefault();

            return  contaxt.Flight.Where(f => f.From == a.Id && f.Takeoff >= time).ToList();
            //var x = contaxt.Flight.Where(c => c.Takeoff>=time).Where(c => c.From==id).ToList();
            
        }

        public List<Flight> GetFlightBydestination(int id)
        {
           

            var x = contaxt.Flight.Where(c => c.To == id).ToList();
            return x;
        }
        //public List<Flight> GetFlightByDate(DateTime time, int id)
        //{
        //    var x= contaxt.Flight.Where(c => c.Takeoff >= time).ToList();
        //    return x;
                
        //}
        public void Update()
        {
            
        }
        public string Delete(string airport)
        {
            
            var comp = contaxt.Company.Where(c => c.Description == airport).FirstOrDefault();
            if (comp!=null) {
            var del = contaxt.Flight.Where(c => c.Company == comp.Id).ToList();
            if(del.Count != 0)
                foreach (var item in del)
                {
                    contaxt.Flight.Remove(item);
                }
            contaxt.Company.Remove(comp);
                contaxt.SaveChanges();
                return $"{airport} deleted!";
            }
            return "this object does not exist";
        }
    }
}
