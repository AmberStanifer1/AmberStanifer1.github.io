using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Models
{
    public class Animal
    {
        public decimal AnimalId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Breed { get; set; }
        public DateTime? Dateborn { get; set; }
        public string Gender { get; set; }
        public string Registered { get; set; }
        public string Color { get; set; }
        public decimal Listprice { get; set; }
        public byte[] Photo { get; set; }
        public string Imagefile { get; set; }
        public decimal Imageheight { get; set; }
        public decimal Imagewidth { get; set; }
    }
}
