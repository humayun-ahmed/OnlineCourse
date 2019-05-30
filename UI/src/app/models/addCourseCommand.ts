import {Guid} from "../utils/CreateGuid";

export class AddCourseCommand {
  courseGuid: string;
  name: string;
  teacher: string;
  maxParticipants: number;
  constructor(name: string, maxParticipants: number, teacher: string) {
    this.courseGuid = Guid.newGuid();
    this.name = name;
    this.maxParticipants = maxParticipants;
    this.teacher = teacher;
  }
}
