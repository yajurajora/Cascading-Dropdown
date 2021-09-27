using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dropdown.Models
{
    public class Cities
    { 
        [Key]
        public int CitiesId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
