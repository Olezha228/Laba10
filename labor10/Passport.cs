using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    public class Passport
    {
        private int s;
        public int sery
        {
            get { return s; }
            set
            {
                if ((value < 0) || (value > 9999))
                    s = 0;
                else 
                    s = value;
                
            }
        }
        public Passport(int s)
        {
            this.s = s;
        }
    }
}
