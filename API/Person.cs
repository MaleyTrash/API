using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Person
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string note { get; set; }

        public Person(string first_name, string last_name, string note = "", int id = 0)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.note= note;
            this.id = id;
      
        }
        public override string ToString()
        {
            return first_name + " " + last_name;
        }
    }
}
