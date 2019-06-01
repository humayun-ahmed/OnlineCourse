using Infrastructure.Validation.Validators;
using OnlineCourse.Api.Dtos.Commands;
using SpecExpress;

namespace OnlineCourse.Api.Dtos.Validation
{
	public class SignupCourseCommandSpecification : Validates<SignupCourseCommand>
    {
        public SignupCourseCommandSpecification()
        {
            this.IsDefaultForType();
           
            this.Check(x => x.Name).Required().MaxLength(200).And.IsValidName();
            this.Check(x => x.Age).Required().GreaterThan(0);
            this.Check(x => x.CourseGuid.ToString())
                .Required()
                .IsRegularExpressionMatch(ConstantValues.GuidRegularExpresssion);
        }
    }
}
