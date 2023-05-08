using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    [Table("Offer")]
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public string Mode { get; set; }
        public string MovementType { get; set; }

        public string Incoterm { get; set; }
        public string CountriesCities { get; set; }

        public string PackageType { get; set; }

        public string Unit1 { get; set; }

        public string Unit2 { get; set; }

        public string Currency { get; set; }
    }
}
