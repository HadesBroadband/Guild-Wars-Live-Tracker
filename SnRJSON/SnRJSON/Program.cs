using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnRJSON
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Data
    {
        private string name;

        public string  Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}
