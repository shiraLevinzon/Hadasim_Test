using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string? Producer { get; set; }
    }
}
