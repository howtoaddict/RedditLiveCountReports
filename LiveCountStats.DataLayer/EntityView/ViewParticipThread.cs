using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.DataLayer.EntityView
{
    public class ViewParticipThread
    {
        public long Pos { get; set; }
        [Key]
        public string Author { get; set; }
        public int KsParticipation { get; set; }

        public override string ToString()
        {
            return String.Format("|{0}|/u/{1}|{2:N0}|", Pos, Author, KsParticipation);
        }
    }
}
