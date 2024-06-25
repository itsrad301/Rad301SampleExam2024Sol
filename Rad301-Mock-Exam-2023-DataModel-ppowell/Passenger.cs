using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_Mock_Exam_2023_DataModel_ppowell
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string TicketType { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal BaggageCharge { get; set; }

        [ForeignKey("Flight")]
        public int FlightId { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
