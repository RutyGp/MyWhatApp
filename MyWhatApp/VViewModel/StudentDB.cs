using MModel;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VViewModel
{
    public class StudentDB:PersonDB
    {
        public StudentList SelectAll()
        {
            command.CommandText = $"SELECT  studentTbl.id, studentTbl.schoolCode, PersonTBL.tz, PersonTBL.fName, PersonTBL.lName, PersonTBL.birthDate FROM            (studentTbl INNER JOIN   PersonTBL ON studentTbl.id = PersonTBL.id)";
            StudentList sList = new StudentList(base.Select());
            return sList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Student st = entity as Student;
            int x = int.Parse(reader["schoolCode"].ToString());
            st.GetSchool = SchoolDB.SelectById(x);
            base.CreateModel(entity);
            return st;
        }
        public override BaseEntity NewEntity()
        {
            return new Student();
        }
        static private StudentList list = new StudentList();

        public static Student SelectById(int id)
        {
            StudentDB db = new StudentDB();
            list = db.SelectAll();

            Student g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Student c = entity as Student;
            if (c != null)
            {
                string sqlStr = $"DELETE FROM StudentTbl where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", c.Id));
            }
        }
        public override void Delete(BaseEntity entity)
        {
            GradesForStudentDB gDB = new GradesForStudentDB();
            GradesForStudentList gFSList= gDB.SelectAll();
            foreach (GradeForStudent grade in gFSList)
                gDB.Delete(grade);

            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }

    }
}
