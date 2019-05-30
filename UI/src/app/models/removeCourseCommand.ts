export class RemoveCourseCommand {
  courseGuid: string;
  constructor( courseGuid: string) {
    this.courseGuid = courseGuid;
  }
}
