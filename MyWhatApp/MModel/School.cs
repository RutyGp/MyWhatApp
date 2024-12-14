using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MModel
{
    public class School:BaseEntity
    {
        public string  SchoolName { get; set; }
        public City SchoolCity { get; set; }
    }
}
