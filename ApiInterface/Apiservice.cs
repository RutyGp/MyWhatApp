using MModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiInterface
{
    public class Apiservice : IApi
    {
        string uri;
        public HttpClient client;
        public Apiservice()
        {
            // uri = "http://localhost:5115";
            uri = "https://jb4cvj60-5115.euw.devtunnels.ms";
                
            client = new HttpClient();
        }

        public async Task<CityList> GetAllCities()
        {
            return await client.GetFromJsonAsync<CityList>(uri + "/api/Insert/citySelector");
        }

        public async Task<int> DeleteACity(int id)
        {
            return  (await client.DeleteAsync(uri+ "/api/Insert/DeleteCity/"+id)).IsSuccessStatusCode ? 1:0;
        }
        
        public async Task<int> UpdateACity(City c)
        {
            return (await client.PutAsJsonAsync<City>(uri + "/api/Insert/UpdateCity", c)).IsSuccessStatusCode ? 1 : 0;
        }
       
        public async Task<int> InsertACity(City c)
        {
            return (await client.PostAsJsonAsync<City>(uri + "/api/Insert/InsertCity", c)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<PersonList> GetAllPersons()
        {
            return await client.GetFromJsonAsync<PersonList>(uri + "/api/Insert/personSelector");
        
        }

        public async Task<int> DeleteAPerson(int id)
        {
            return (await client.DeleteAsync(uri + "/api/Insert/DeletePerson/" + id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateAPerson(Person c)
        {
            return (await client.PutAsJsonAsync<Person>(uri + "/api/Insert/UpdatePerson", c)).IsSuccessStatusCode ? 1 : 0;
        
        }

        public  async Task<int> InsertAPerson(Person c)
        {
            return (await client.PutAsJsonAsync<Person>(uri + "/api/Insert/InsertPerson", c)).IsSuccessStatusCode ? 1 : 0;
        }
    }
}

