using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_SQL.Model
{
    internal class Student
    {//student have many gradings, course, and teachers. one class.
        public int Id { get; set; }
        public int KlassId { get; set; }
        public int GradingId { get; set; }
        public string StudentName { get; set; }

        public virtual Klass Klass { get; set; }
        public virtual ICollection<Grading> Gradings { get; set; }
    }
}
