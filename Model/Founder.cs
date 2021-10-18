using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reactNetDemo.Model
{
    public class Founder
    {
        public string name { get; set; }

        public string address { get; set; }
        public Founder()
        {
            this.name = "Jaspreet Singh Mahal";
            this.address = "mohali";
        }
    }
}
