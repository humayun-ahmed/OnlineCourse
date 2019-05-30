import { Component, OnInit } from '@angular/core';
import {Course} from "../models/course";
import {CourseService} from "../services/course.service";
import {finalize} from "rxjs/internal/operators";
import { FormsModule,FormGroup, FormBuilder, FormControl, Validators,ReactiveFormsModule } from '@angular/forms';
import {Router, ActivatedRoute} from "@angular/router";
import {ToastrService} from "ngx-toastr";

@Component({
  providers: [CourseService],
  selector: 'app-edit-course',
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.css']
})
export class EditCourseComponent implements OnInit {

  public course : Course = new Course();
  public addNewsForm: FormGroup;
  public isNew: boolean=true;

  public id: string;
  constructor(public formBuilder: FormBuilder,
              private courseService : CourseService,
              private router: Router,
              private toastrService: ToastrService,
              private activatedRoute: ActivatedRoute ) { }

  ngOnInit() {

    this.activatedRoute.params.subscribe(params => {
      var id = params.id;
      if (id){
        this.isNew = false;
        this.id = id;
        this.loadCourse(this.id);
      }
    });

  }

  loadCourse(id){
    this.courseService.getCourseById(id)
      .pipe(finalize(() => {})
      ).subscribe((p : Course) => {
      this.course = p;
    }, error => {
    });
  }

  onSubmit() {
    if(this.isNew){
      this.addCourse(this.course);
    }
    else{
      this.saveCourse(this.course);
    }
  }


  saveCourse(course) {
    this.courseService.updateCourse(course)
      .pipe(finalize(() => {

        })
      ).subscribe((p: any) => {
      this.toastrService.success('Successfully course saved', 'Success!');
      this.router.navigate(['/']);
    }, error => {
      this.toastrService.error('Error. Try again!!', 'Oops!');
    });
  }

  addCourse(course) {
    this.courseService.addCourse(course)
      .pipe(finalize(() => {

        })
      ).subscribe((p: Course) => {
      this.toastrService.success('Successfully course added', 'Success!');
      this.router.navigate(['/']);
    }, error => {
      this.toastrService.error('Error. Try again!!', 'Oops!');
    });
  }
}
