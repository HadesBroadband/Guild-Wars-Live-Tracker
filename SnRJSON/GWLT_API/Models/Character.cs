using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GWLT_API.Models
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public float xCoord { get; set; }
        public float yCoord { get; set; }
        public float zCoord { get; set; }
    }
}