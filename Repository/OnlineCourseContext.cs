using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Infrastructure.Repository;
using OnlineCourse.Repository.EtConfiguration;
using OnlineCourse.Repository.Models;

namespace OnlineCourse.Repository
{
	public class OnlineCourseContext : ContextBase
    {
        public OnlineCourseContext()
        {
            
        }

        public OnlineCourseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        public OnlineCourseContext(DbConnection existingConnection)
            : base(existingConnection)
        {
            // TODO: Need to analyze the performance of this audit mechanism
           // this.Audit();
        }

        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CourseConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}