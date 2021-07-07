using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    class SortByHeight : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;
            if (p1.Height < p2.Height) return -1;
            else if (p1.Height > p2.Height) return 1;
            else return 0;
        }
    }
}
