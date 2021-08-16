using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Flight
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DateTime Takeoff { get; set; }
        public DateTime Landing { get; set; }
        public int Company { get; set; }

        public Company CompanyNavigation { get; set; }
        public Airport FromNavigation { get; set; }
        public Airport ToNavigation { get; set; }
    }
}
