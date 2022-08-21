using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisilerManagement.Models
{
    public class Kisiler
    {
        public int Id { get; set; }
        public int UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
    }
}
