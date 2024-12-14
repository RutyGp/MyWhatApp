using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MModel;
using VViewModel;

namespace ApiExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        [HttpGet]
        [ActionName("citySelector")]
        public CityList SelectAllCities()
        {
            CityDB cDB = new();
            CityList cities = cDB.SelectAll();
            return cities;
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteCity")]
        public int DeleteACity(int id)
        {
            City c = CityDB.SelectById(id);
            CityDB cDB = new CityDB();
            cDB.Delete(c);
            int x = cDB.SaveChanges();
            return x;
        }

     

        [HttpPut]
        [ActionName("UpdateCity")]
        public int UpdateACity([FromBody] City c)
        {
            CityDB cDB = new CityDB();
            cDB.Update(c);
            int x = cDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertCity")]
        public int InsertACity([FromBody] City c)
        {
            CityDB cDB = new CityDB();
            cDB.Insert(c);
            int x = cDB.SaveChanges();
            return x;
        }
        [HttpGet]
        [ActionName("personSelector")]
        public PersonList SelectAllPersons()
        {
            PersonDB cDB = new();
            PersonList pList = cDB.SelectAll();
            return pList;
        }

        [HttpDelete("{id}")]
        [ActionName("DeletePerson")]
        public int DeleteAPerson(int id)
        {
            Person c = PersonDB.SelectById(id);
            PersonDB cDB = new PersonDB();
            cDB.Delete(c);
            int x = cDB.SaveChanges();
            return x;
        }



        [HttpPut]
        [ActionName("UpdatePerson")]
        public int UpdateAPerson([FromBody] Person c)
        {
            PersonDB cDB = new PersonDB();
            cDB.Update(c);
            int x = cDB.SaveChanges();
            return x;
        }
        [HttpPost]
        [ActionName("InsertPerson")]
        public int InsertAPerson([FromBody] Person c)
        {
            PersonDB cDB = new PersonDB();
            cDB.Insert(c);
            int x = cDB.SaveChanges();
            return x;
        }
    }
}
