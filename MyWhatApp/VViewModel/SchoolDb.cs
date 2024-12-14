using MModel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VViewModel
{
    public class SchoolDB:BaseEntityDB
    {
        public SchoolList SelectAll()
        {
            command.CommandText = $"SELECT * FROM SchoolTbl";
            SchoolList sList = new SchoolList(base.Select());
            return sList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            School scl = entity as School;
            scl.SchoolName = reader["SchoolName"].ToString();
            scl.SchoolCity = CityDB.SelectById(int.Parse(reader["schoolCity"].ToString()));
            base.CreateModel(entity);
            return scl;
        }
        public override BaseEntity NewEntity()
        {
            return new School();
        }
        static private SchoolList list = new SchoolList();

        public static School SelectById(int id)
        {
            SchoolDB db = new SchoolDB();
            list = db.SelectAll();

            School g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            School c = entity as School;
            if (c != null)
            {
                string sqlStr = $"DELETE FROM SchoolTbl where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", c.Id));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
