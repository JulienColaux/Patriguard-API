using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Propriete
    {
        public int id { get; set; }
        public string adresse { get; set; }
        public int valeur { get; set; }
        public int userId { get; set; }
        public string description { get; set; }
    }
}
