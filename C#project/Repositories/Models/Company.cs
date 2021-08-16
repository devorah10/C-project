using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Company
    {
        public Company()
        {
            Flight = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Flight> Flight { get; set; }
    }
}
