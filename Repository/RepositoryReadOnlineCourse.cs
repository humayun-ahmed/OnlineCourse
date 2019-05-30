using Infrastructure.ReadModel;
using Infrastructure.Repository.Contracts;

namespace OnlineCourse.Repository
{
	public class RepositoryReadOnlineCourse : ReadOptimizedRepository<OnlineCourseReadContext>, IRepositoryReadOnlineCourse
    {
        public RepositoryReadOnlineCourse(IDbContextFactory<OnlineCourseReadContext> dbContextProvider): base(dbContextProvider)
        {
            
        }
    }
}
