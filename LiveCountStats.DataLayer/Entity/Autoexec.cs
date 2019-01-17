using LivecountStats.DataLayer.EntityTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.DataLayer.Entity
{
    public class Autoexec
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoexectId { get; set; }

        [StringLength(50)]
        public string TaskName { get; set; }

        [StringLength(50)]
        public string TaskParams { get; set; }

        public DateTime NextRunTime { get; set; }

        public RepeatUnits RepeatUnit { get; set; }

        public int RepeatValue { get; set; }
    }
}
