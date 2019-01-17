using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.DataLayer
{
    public sealed class AppConfigDatabase : DbMigrationsConfiguration<AppDataContext>
    {
        public AppConfigDatabase()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LivecountStats.DataLayer.AppDataContext";

            // When you have huge data migration transaction consider enabling
            CommandTimeout = 60 * 1;
        }

        protected override void Seed(AppDataContext context)
        {
        }
    }
}
