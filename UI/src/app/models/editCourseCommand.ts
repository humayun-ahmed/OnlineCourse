import {Guid} from "../utils/CreateGuid";

export class EditCourseCommand {
  courseGuid: string;
  name: string;
  teacher: string;
  maxParticipants: number;
  constructor( courseGuid: string, name: string, maxParticipants: number, teacher: string) {
    this.courseGuid = courseGuid;
    this.name = name;
    this.maxParticipants = maxParticipants;
    this.teacher = teacher;
  }
}
