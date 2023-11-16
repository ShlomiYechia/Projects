using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV3
{
    public struct Birthday
    {
        public int month { get; set; }
        public int day { get; set; }
        public Birthday(DateTime date)
        {
            month = date.Month;
            day = date.Day;
        }
    }
}
