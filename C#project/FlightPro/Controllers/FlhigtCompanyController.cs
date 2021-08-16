using Microsoft.AspNetCore.Mvc;
using Service;
using Service.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FlhigtCompanyController : ControllerBase
    {
        ICompanyService cms;
        public FlhigtCompanyController(ICompanyService cms)
        {
            this.cms = cms;
        }
        [HttpGet("GetCompanyFlight")]

        public List<companyVM> GetCompanyFlight()
        {

            return cms.GetCompanyByFlight();
        }
        [HttpGet("date/{time}/{idTerminal}")]
        public ActionResult<List<FlightVM>> GetFlightByDate(DateTime time, string idTerminal)
        {
            //if (idTerminal < 0)
            //    return BadRequest("idTerminal must be greater than 0");
            var list = cms.GetFlightByDate(time, idTerminal);
            if (list.Count == 0)
                return NotFound("not found");
            return list;
        }

        [HttpGet("flight/{id}")]
        public ActionResult<List<FlightVM>> GetFlightByCompany(int id)
        {
            if (id < 0)
                return BadRequest("id must be greater than 0");
            var list = cms.GetFlightByCompany(id);
            if (list.Count == 0)
                return NotFound("not found");
            return list;
        }

        [HttpGet("destination/{To}")]
        public ActionResult<List<FlightVM>> GetFlightBydestination(int To)
        {
            if (To < 0)
                return BadRequest("destination must be greater than 0");
            var list = cms.GetFlightBydestination(To);
            if (list.Count == 0)
                return NotFound("not found");
            return list;
        }
        
        [HttpPost("Add")]
        public int Add(companyVM cmv)
        {
            return cms.Add(cmv);
        }
        [HttpGet("Delete/{airport}")]
        public string Delete(string airport)
        {
            return cms.Delete(airport);
        }

    }
}
