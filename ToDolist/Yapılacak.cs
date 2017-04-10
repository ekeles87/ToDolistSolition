using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDolist
{
    public class Yapılacak
    {
        public string not { get; set; }
        public DateTime iszaman { get; set; }
        public DateTime tamtarih { get; set; }
        public bool durum { get; set; }

        public override string ToString()
        {
            return not;
        }
    }
}
