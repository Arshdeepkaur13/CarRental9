using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class CarRental
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Customer Customers { get; set; }
        public Car Cars { get; set; }

        public List<Fine> Fines { get; set; }

    }
}