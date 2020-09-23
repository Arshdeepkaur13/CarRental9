using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class Fine
    {
        public int ID { get; set; }
        public int CarRentalID { get; set; }
        public decimal AmountFine { get; set; }
        public decimal FineDeposit { get; set; }
        public DateTime DepositDate { get; set; }

        public CarRental CarRentals { get; set; }
    }
}