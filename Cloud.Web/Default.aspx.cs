using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI;
using Azure.Models;
using Newtonsoft.Json;

namespace Cloud.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var employees = new List<PersonModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://destro-api.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string response = client.GetStringAsync("api/person").Result;
                    employees = JsonConvert.DeserializeObject<List<PersonModel>>(response);
                }
                catch (Exception ex)
                {
                }
            }
            gvEmployee.DataSource = employees;
            gvEmployee.DataBind();
        }

    }
}