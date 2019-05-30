import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import {PagedCourses} from "../models/pagedCourses";
import {Course} from "../models/course";
import {SearchCourse} from "../models/searchCourse";
import {debounceTime} from "rxjs/internal/operators";
import {EditCourseCommand} from "../models/editCourseCommand";
import {AddCourseCommand} from "../models/addCourseCommand";
import {RemoveCourseCommand} from "../models/removeCourseCommand";
import {HttpHeaders} from "@angular/common/http";

// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class CourseService {

  constructor(private http: HttpClient) { }

  getAllCourses(pageNumber: number,pageSize: number, searchKey: string = ''): Observable<PagedCourses> {
    let url=`api/CourseQuery/Get`;
    let searchCourse=new SearchCourse(pageNumber, pageSize, searchKey);

    return this.http.post<any>(url, JSON.stringify(searchCourse)).pipe(
      debounceTime(300),
      map((res: HttpResponse<any>) => {
      let pagedClient = res as PagedCourses;
      return pagedClient;
    }));

  }

  getCourseById(id: string): Observable<Course> {
    let url = `api/CourseQuery/GetById?id=${id}`;
    return this.http.get<any>(url, { observe: 'response' as 'response' }).pipe(map((res: HttpResponse<Course>) => {
      let p = res.body as Course;
      return p;
    }));
  }

  addCourse(course: Course): Observable<any> {
    let command=new AddCourseCommand(course.name, course.maxParticipants, course.teacher);
    let url = `api/Course/Add`;
    return this.http.post<any>(url, JSON.stringify(command));
  }

  updateCourse(course: Course): Observable<any> {
    let command=new EditCourseCommand(course.courseGuid, course.name, course.maxParticipants, course.teacher);
    let url = `api/Course/Edit`;
    return this.http.put<any>(url, JSON.stringify(command));
  }

  deleteCourse(courseGuid: string): Observable<any> {
    let command2 = new RemoveCourseCommand(courseGuid);
    let url = `api/Course/Remove`;

    let options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: command2,
    };

    return this.http.delete<any>(url, options);
  }


}
