using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MModel
{
    public class SchoolList:List<School>
    {
        public SchoolList() { }

        public SchoolList(IEnumerable<School> list) : base(list) { }

        public SchoolList(IEnumerable<BaseEntity> list) : base(list.Cast<School>().ToList()) { }
    }
}