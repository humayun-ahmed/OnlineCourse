using Infrastructure.ReadModel;
using Infrastructure.Repository.Contracts;

namespace OnlineCourse.Repository
{
	public class RepositoryOnlineCourse : Repository<OnlineCourseContext>, IRepositoryOnlineCourse
    {
        public RepositoryOnlineCourse(IDbContextFactory<OnlineCourseContext> dbContextProvider): base(dbContextProvider)
        {
            
        }
    }
}
