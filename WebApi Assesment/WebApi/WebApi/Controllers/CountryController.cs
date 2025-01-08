using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Models.Countries;

namespace WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class CountryController : ApiController
    {
        List<Country> countries = new List<Country>();

        public CountryController()
        {
            countries.Add(new Country { ID = 1, CountryName = "India", Capital = "Delhi" });
            countries.Add(new Country { ID = 2, CountryName = "Japan", Capital = "Tokyo" });
            countries.Add(new Country { ID = 3, CountryName = "Australia", Capital = "Sydney" });
        }


        [HttpGet]
        [Route("All")]
        public HttpResponseMessage GetAllPGetAllCountries()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countries);
            return response;
        }
        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetCountryById(int cId)
        {
            string cname = countries.Where(c => c.ID == cId).SingleOrDefault()?.CountryName;
            if (cname == null)
            {
                return NotFound();
            }
            return Ok(cname);
        }
        // POST api/country
        [HttpPost]
        [Route("AllPost")]
        public List<Country> PostAll([FromBody] Country country)
        {
            countries.Add(country);
            return countries;
        }
        [HttpPut]
        [Route("Put")]
        public IEnumerable<Country> Put(int Cid, [FromUri] Country c)
        {
            countries[Cid - 1] = c;
            return countries;
        }
        [HttpDelete]
        [Route("Delete")]
        public IEnumerable<Country> Delete(int cid)
        {
            countries.RemoveAt(cid - 1);
            return countries;
        }
    }
}