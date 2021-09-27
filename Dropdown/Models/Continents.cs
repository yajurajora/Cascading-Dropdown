using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dropdown.Models
{
    public class Continents
    {
        [Key]
        public int ContinentId { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public int CountriesId { get; set; }
        [NotMapped]
        public int CitiesId { get; set; }
    }
}
