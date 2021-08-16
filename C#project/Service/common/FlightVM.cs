using System;
using System.Collections.Generic;
using System.Text;

namespace Service.common
{
    public class FlightVM
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DateTime Takeoff { get; set; }
        public DateTime Landing { get; set; }
        public int Company { get; set; }
    }
}
