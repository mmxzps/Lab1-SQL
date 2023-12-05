using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_SQL.Model
{
    internal class Course
    {//Course have many students, grade? one staff?
        public int Id { get; set; }
        public string CourseName { get; set; }
    }
}
