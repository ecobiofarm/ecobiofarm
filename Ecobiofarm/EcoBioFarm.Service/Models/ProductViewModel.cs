using EcoBioFarm.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoBioFarm.Service.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Description { get; set; }

        public virtual IEnumerable<Cut> Cuts { get; set; }

        public string Discount { get; set; }
    }
}
