using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Models
{
    public class City
    {
        public decimal CityID { get; set; }

        public string ZipCode { get; set; }

        public string CityChoice { get; set; }

        public string State { get; set; }

        public string AreaCode { get; set; }

        public decimal Population1990 { get; set; }

        public decimal Popularion1980 { get; set; }

        public string Country { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

    }
}
