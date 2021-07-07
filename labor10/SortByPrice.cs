using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    class SortByPrice : IComparer
    {
        public int Compare(object x, object y)
        {
            CorrespondenceStudent p1 = (CorrespondenceStudent)x;
            CorrespondenceStudent p2 = (CorrespondenceStudent)y;
            if (p1.PriceOfStudying < p2.PriceOfStudying) return -1;
            else if (p1.PriceOfStudying > p2.PriceOfStudying) return 1;
            else return 0;
        }
    }
}
