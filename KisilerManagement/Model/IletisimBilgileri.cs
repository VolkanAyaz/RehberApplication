using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KisilerManagement.Models
{
    public class IletisimBilgileri
    {
        public int Id { get; set; }
        [ForeignKey("KisiID")]
        public int KisiID { get; set; }
        public virtual Kisiler Kisi { get; set; }
        [ForeignKey("BilgiTipiID")]
        public int BilgiTipiID { get; set; }
        public virtual BilgiTipleri BilgiTipi { get; set; }
        public string BilgiIcerigi { get; set; }
    }
}
