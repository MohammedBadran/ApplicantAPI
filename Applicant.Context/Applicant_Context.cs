using Applicant.Domain;
using Microsoft.EntityFrameworkCore;

namespace Applicant.Context
{
    public class Applicant_Context:DbContext
    {
        public Applicant_Context(DbContextOptions<Applicant_Context> options) : base(options)
        {

        }
        public DbSet<Applicants> Applicants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Area Mapping
            modelBuilder.Entity<Applicants>();
            #endregion
            base.OnModelCreating(modelBuilder);
        }

    }
}
