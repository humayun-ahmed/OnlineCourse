using System.Data.Common;

namespace OnlineCourse.Repository
{
	public class OnlineCourseReadContext : OnlineCourseContext
    {
        public OnlineCourseReadContext()
        {
        }

        public OnlineCourseReadContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public OnlineCourseReadContext(DbConnection existingConnection)
            : base(existingConnection)
        {
            // TODO: Need to analyze the performance of this audit mechanism
            // this.Audit();
        }
    }
}