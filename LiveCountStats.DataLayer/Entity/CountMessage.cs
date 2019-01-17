using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.DataLayer.Entity
{
    public class CountMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountMessageId { get; set; }

        public string body { get; set; }

        [StringLength(50)]
        [Index("IX_author")]
        public string author { get; set; }
        public bool stricken { get; set; }

        [StringLength(50)]
        public string id { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        public int created_utc { get; set; }

        [Index]
        public int? counter { get; set; }


        /*
    {
      "body":"65,700",
      "name":"LiveUpdate_fd811952-5fa7-11e4-9cc4-12313d149cad",
      "author":"GrunfTNT",
      "embeds":[ ],
      "created":1414642384,
      "created_utc":1414613584,
      "body_html":"&lt;div class=\"md\"&gt;&lt;p&gt;65,700&lt;/p&gt;\n&lt;/div&gt;",
      "stricken":false,
      "id":"fd811952-5fa7-11e4-9cc4-12313d149cad"
    }
         */
    }
}
