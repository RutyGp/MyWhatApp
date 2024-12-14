using MModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInterface
{
    public interface IApi
    {
        public Task<CityList> GetAllCities();
        public Task<int> DeleteACity(int id);
        public Task<int> UpdateACity(City c);
        public Task<int> InsertACity(City c);
        public Task<PersonList> GetAllPersons();
        public Task<int> DeleteAPerson(int id);
        public Task<int> UpdateAPerson(Person c);
        public Task<int> InsertAPerson(Person c);
    }
}
