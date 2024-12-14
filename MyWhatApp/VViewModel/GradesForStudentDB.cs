using MModel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VViewModel
{
    public class GradesForStudentDB:BaseEntityDB
    {
        public GradesForStudentList SelectAll()
        {
            command.CommandText = $"SELECT * FROM GradesForStudentTbl";
            GradesForStudentList gList = new GradesForStudentList(base.Select());
            return gList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            GradeForStudent gFS = entity as GradeForStudent;
            //gFS.IdStudent = StudentDB.SelectById(int.Parse(reader["idStudent"].ToString());
            //gFS.IdTeacher = TeacherDB.SelectById(int.Parse(reader["idStudent"].ToString());
            //gFS..SchoolCity = CityDB.SelectById(int.Parse(reader["schoolCity"].ToString()));
            //base.CreateModel(entity);
            return gFS;
        }

        public override BaseEntity NewEntity()
        {
            return new GradeForStudent();
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            GradeForStudent gFStd = entity as GradeForStudent;
            if (gFStd != null)
            {
                string sqlStr = $"DELETE FROM GradesForStudentTbl where id=@sid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@sid", gFStd.Id));
            }
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
