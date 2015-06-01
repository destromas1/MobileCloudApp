using System.Collections.Generic;
using System.Web.Http;
using Azure.Models;
using Azure.Repositories;

namespace MobileCloudApp.Controllers
{
    public class DistrictController : ApiController
    {

        private AzureDBEntities _entities;

        public DistrictController()
        {
            _entities = new AzureDBEntities();
        }

        // GET api/district
        public IEnumerable<DistrictModel> Get()
        {
            var districts = new List<DistrictModel>();
            foreach (var district in _entities.Districts)
            {
                districts.Add(new DistrictModel(){Id = district.DistrictId , Name = district.DistrictName});
            }
            return districts;
        }

        // GET api/district/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/district
        public void Post([FromBody]string value)
        {
        }

        // PUT api/district/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/district/5
        public void Delete(int id)
        {
        }
    }
}
