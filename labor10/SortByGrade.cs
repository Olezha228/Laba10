using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    class SortByGrade : IComparer
    {
        public int Compare(object x, object y)
        {
            Schooler sch1 = (Schooler)x;
            Schooler sch2 = (Schooler)y;
            if (sch1.SchoolYear < sch2.SchoolYear) return -1;
            else if (sch1.SchoolYear > sch2.SchoolYear) return 1;
            else return 0;
        }
    }
}
