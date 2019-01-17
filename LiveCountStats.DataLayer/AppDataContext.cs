using LivecountStats.DataLayer.Entity;
using LivecountStats.DataLayer.EntityView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.DataLayer
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base("AppDataContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        // tables
        public DbSet<Autoexec> Autoexecs { get; set; }

        public DbSet<CountMessage> CountMessages { get; set; }

        public DbSet<Veteran> Veterans { get; set; }

        // views
        public DbSet<ViewAssist> ViewAssists { get; set; }
        public DbSet<ViewCounter> ViewCounters { get; set; }
        public DbSet<ViewParticipDay> ViewParticipDays { get; set; }
        public DbSet<ViewParticipThread> ViewParticipThreads { get; set; }
        public DbSet<ViewGet> ViewGets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //PrecisionAttribute.ConfigureModelBuilder(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public static AppDataContext CreateConnection()
        {
            return new AppDataContext();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}

