﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dropdown.Models
{
    public class Countries
    {
        [Key]
        public int CountriesId { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }
    }
}
