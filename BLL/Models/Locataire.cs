using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Locataire
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string? mail { get; set; }
        public string? telephone { get; set; }
        public string? description { get; set; }
    }
}
