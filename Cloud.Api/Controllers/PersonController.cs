using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Azure.Models;
using Azure.Repositories;


namespace MobileCloudApp.Controllers
{
    public class PersonController : ApiController
    {
        private AzureDBEntities _entities;

        public PersonController()
        {
            _entities = new AzureDBEntities();
        }

        // GET api/person
        public IEnumerable<PersonModel> Get()
        {
            var employees = new List<PersonModel>();
            foreach (var person in _entities.People)
            {
                employees.Add(new PersonModel() 
                { 
                    EmployeeId = person.ID, 
                    FirstName= person.FirstName,
                    LastName = person.LastName,
                    DistrictId = person.DistrictId,
                    DistrictName = person.District.DistrictName,
                    JoiningDate = person.CreationDate
                });
            }
            return employees;
        }

        // GET api/person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/person
        [HttpPost]
        public HttpResponseMessage Post(PersonModel employeeModel)
        {
            try 
            {
                var employee = new Person();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                employee.DistrictId = employeeModel.DistrictId;
                employee.FirstName = employeeModel.FirstName;
                employee.LastName = employeeModel.LastName;
                employee.CreationDate = employeeModel.JoiningDate;
                _entities.People.Add(employee);
                _entities.SaveChanges();
                return  new HttpResponseMessage(){StatusCode = HttpStatusCode.OK};
            }
            catch (Exception e)
            {
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError };
            }
        }

        // PUT api/person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/person/5
        public void Delete(int id)
        {
        }
    }
}
