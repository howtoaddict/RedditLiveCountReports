using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.DataLayer.Entity
{
    public class Veteran
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VeteranId { get; set; }

        [StringLength(50)]
        [Required]
        public string VeteranName { get; set; }
    }
}
