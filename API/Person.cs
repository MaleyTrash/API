using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Person
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string note { get; set; }

        public override string ToString()
        {
            return first_name + " " + last_name;
        }
    }
}
