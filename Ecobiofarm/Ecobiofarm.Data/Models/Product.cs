using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecobiofarm.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Cuts = new HashSet<Cut>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public virtual IEnumerable<Cut> Cuts { get; set; }

        public string Discount { get; set; }
    }
}
