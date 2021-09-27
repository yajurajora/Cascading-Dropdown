using Dropdown.DropdownContext;
using Dropdown.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Continents> continentsList = new List<Continents>();

            //----Getting Data From Database using EntityFramework Core---
            continentsList = (from Continents in _context.tblContinents
                              select Continents).ToList();

            //Inserting Select item in List----
            continentsList.Insert(0, new Continents { ContinentId = 0, Name = "Select" });

            ViewBag.ListOfContinents = continentsList;

            return View();
        }

        [HttpPost]
        public IActionResult Index(Continents objcontinents,IFormCollection formCollection)
        {
            if(objcontinents.ContinentId==0)
            {
                ModelState.AddModelError("", "Select Continent");
            }
            else if (objcontinents.CountriesId == 0)
            {
                ModelState.AddModelError("", "Select Countries");
            }
            else if (objcontinents.CitiesId == 0)
            {
                ModelState.AddModelError("", "Select Cities");
            }

            //-----Getting Selected value-----
            var contriesId = HttpContext.Request.Form["ContriesId"].ToString();
            var citiesId = HttpContext.Request.Form["CititesId"].ToString();

            //----Seeting Data back to viewbag after posting form---
            List<Continents> continentsList = new List<Continents>();

            continentsList = (from Continents in _context.tblContinents
                              select Continents).ToList();

           
            continentsList.Insert(0, new Continents { ContinentId = 0, Name = "Select" });
            ViewBag.ListOfContinents = continentsList;
            return View();
        }

        public JsonResult GetCountry(int continentId)
        {
            List<Countries> countriesList = new List<Countries>();

            //----Getting Data From Database using EntityFramework Core---
            countriesList = (from Countries in _context.tblCountries
                             where Countries.ContinentId == continentId
                             select Countries).ToList();

            //Inserting Select item in List----
            countriesList.Insert(0, new Countries { CountriesId = 0, Name = "Select" });

            return Json(new SelectList(countriesList, "CountriesId", "Name"));

        }

        public JsonResult GetCities(int countriesId)
        {
            List<Cities> citiesList = new List<Cities>();

            //----Getting Data From Database using EntityFramework Core---
            citiesList = (from Cities in _context.tblCities
                             where Cities.CountryId == countriesId
                          select Cities).ToList();

            //Inserting Select item in List----
            citiesList.Insert(0, new Cities { CitiesId = 0, Name = "Select" });

            return Json(new SelectList(citiesList, "CitiesId", "Name"));

        }
    }
}
