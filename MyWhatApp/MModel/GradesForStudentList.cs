using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MModel
{
    public class GradesForStudentList:List<GradeForStudent>
    {
        public GradesForStudentList() { }

        public GradesForStudentList(IEnumerable<GradeForStudent> list) : base(list) { }

        public GradesForStudentList(IEnumerable<BaseEntity> list) : base(list.Cast<GradeForStudent>().ToList()) { }

    }
}
