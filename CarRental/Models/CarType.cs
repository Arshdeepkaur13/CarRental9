using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class CarType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }

        public List<Car> Cars { get; set; }
    }
}