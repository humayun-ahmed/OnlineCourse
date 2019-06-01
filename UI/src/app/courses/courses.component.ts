import { Component, OnInit } from '@angular/core';
import { finalize } from "rxjs/operators";
import { FormControl, Validators, FormBuilder, FormGroup } from "@angular/forms";
import { Course } from "../models/course";
import {CourseService} from "../services/course.service";
import {AppConfig} from "../app.config";
import {PagedCourses} from "../models/pagedCourses";
import {ToastrService} from "ngx-toastr";
import {ExcelService} from "../services/excel.service";

@Component({
  providers: [CourseService, FormBuilder, ExcelService],
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  public searchKey : string = "";
  public page: number  = 1;
  public courses: Course[] = [];
  public course : Course;
  public selectedCourse : Course;
  public isSubmitted : boolean;
  public totalItems : number;
  public itemsPerPage : number = AppConfig.itemsPerPage;


  constructor(private courseService : CourseService
    , public formBuilder: FormBuilder
    ,private toastrService: ToastrService
    ,private excelService: ExcelService) {
  }


  ngOnInit() {
    this.loadData(this.page);
  }

  exportAsXLSX():void {
    this.excelService.exportAsExcelFile(this.courses, 'course');
  }

  loadData(page){
    this.courseService.getAllCourses(page, this.itemsPerPage, this.searchKey)
      .pipe(finalize(() => {})
      ).subscribe((pagedNews : PagedCourses) => {
      this.totalItems = pagedNews.total;
      this.courses = pagedNews.data;
    }, error => {
    });
  }

  deleteCourse(course : Course){
    var res = confirm("Are you sure to delete this course?");
    if (res == false) {
      return;
    }
    else{
      this.courseService.deleteCourse(course.courseGuid)
        .pipe(finalize(() => {
          })
        ).subscribe((res : any) => {
        this.loadData(1);
        this.toastrService.success('Course deleted', 'Success!');
      }, error => {
        this.toastrService.error('Error. Try again!!', 'Oops!');
      });
    }
  }
  signupCourse(course : Course){
    this.courseService.deleteCourse(course.courseGuid)
      .pipe(finalize(() => {
        })
      ).subscribe((res : any) => {
      this.loadData(1);
      this.toastrService.success('Course deleted', 'Success!');
    }, error => {
      this.toastrService.error('Error. Try again!!', 'Oops!');
    });
  }

}
