using Infrastructure.Validation.Validators;
using OnlineCourse.Api.Dtos.Commands;
using SpecExpress;

namespace OnlineCourse.Api.Dtos.Validation
{
	public class AddCourseCommandSpecification : Validates<AddCourseCommand>
    {
        public AddCourseCommandSpecification()
        {
            this.IsDefaultForType();
           
            this.Check(x => x.Name).Required().MaxLength(200).And.IsValidName();
            this.Check(x => x.Teacher).Optional().MaxLength(1000).And.IsValidName();
            this.Check(x => x.MaxParticipants).Required().GreaterThan(0);
            this.Check(x => x.CourseGuid.ToString())
                .Required()
                .IsRegularExpressionMatch(ConstantValues.GuidRegularExpresssion);
        }
    }
}
