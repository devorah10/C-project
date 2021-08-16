                                                                                                                                                                                                                                                                                                                   using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Airport
    {
        public Airport()
        {
            FlightFromNavigation = new HashSet<Flight>();
            FlightToNavigation = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Flight> FlightFromNavigation { get; set; }
        public ICollection<Flight> FlightToNavigation { get; set; }
    }
}
