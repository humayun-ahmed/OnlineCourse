using Infrastructure.Validation.Validators;
using OnlineCourse.Api.Dtos.Commands;
using SpecExpress;

namespace OnlineCourse.Api.Dtos.Validation
{
	public class RemoveCourseCommandSpecification : Validates<RemoveCourseCommand>
    {
        public RemoveCourseCommandSpecification()
        {
            this.IsDefaultForType();

            this.Check(x => x.CourseGuid.ToString())
                .Required()
                .IsRegularExpressionMatch(ConstantValues.GuidRegularExpresssion);
        }
    }
}
