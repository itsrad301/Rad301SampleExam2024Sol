﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_Mock_Exam_2023_DataModel_ppowell
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [DisplayName("Flight Number")]
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Country { get; set; }
        [DisplayName("Maximum number of Seats")]
        public int MaxSeats { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
