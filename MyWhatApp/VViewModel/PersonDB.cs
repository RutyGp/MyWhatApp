using MModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VViewModel
{
    public class PersonDB:BaseEntityDB
    {
        public PersonList SelectAll()
        {
            command.CommandText = $"SELECT * FROM PersonTbl";
            PersonList pList = new PersonList(base.Select());
            return pList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Person  per = entity as Person;
           
            per.FName = reader["fname"].ToString();
            per.LName = reader["lname"].ToString();
            per.TZ = reader["tz"].ToString();
            per.BirthDate = DateTime.Parse(reader["birthDate"].ToString());
            base.CreateModel(entity);
            return per;
        }
        public override BaseEntity NewEntity()
        {
            return new Person();
        }
        static private PersonList list = new PersonList();

        public static Person SelectById(int id)
        {
            PersonDB perDb = new PersonDB();
            list = perDb.SelectAll();

            Person per = list.Find(item => item.Id == id);
            return per;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Person per = entity as Person;
            if (per != null)
            {
                string sqlStr = $"DELETE FROM PersonTbl where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", per.Id));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
