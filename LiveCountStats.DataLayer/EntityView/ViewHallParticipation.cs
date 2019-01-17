using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.DataLayer.EntityView
{
    public class ViewHallParticipation
    {
        public long Pos { get; set; }
        [Key]
        public string Author { get; set; }
        public int Score { get; set; }
        public int Counts { get; set; }
        public int Gets { get; set; }
        public int Assists { get; set; }
        public int GetsAndAssists { get; set; }
        public int KsParticipated { get; set; }
        public int DaysParticipated { get; set; }
        public decimal GetsRatio { get; set; }
        public decimal AssistsRatio { get; set; }
        public decimal CombinedRatio { get; set; }

        public override string ToString()
        {
            // TODO: Maybe replace by property names
            return String.Format("| {0} | /u/{1} | {2:N0} | {3:N0} | {4:N0} | {5:N0} | {6:N0} | {7:N0} | {8:N0} | {9:N4} | {10:N4} | {11:N4}",
                Pos, Author, Score, Counts, Gets, Assists, GetsAndAssists, KsParticipated, DaysParticipated, GetsRatio, AssistsRatio, CombinedRatio);
        }
    }
}
