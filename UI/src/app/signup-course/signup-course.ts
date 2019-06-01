import { Component, OnInit } from '@angular/core';
import {Course} from "../models/course";
import {CourseService} from "../services/course.service";
import {finalize} from "rxjs/internal/operators";
import { FormsModule,FormGroup, FormBuilder, FormControl, Validators,ReactiveFormsModule } from '@angular/forms';
import {Router, ActivatedRoute} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {SignupCourseCommand} from "../models/signupCourseCommand";

@Component({
  providers: [CourseService],
  selector: 'app-edit-course',
  templateUrl: './signup-course.component.html',
  styleUrls: ['./signup-course.component.css']
})
export class SignupCourseComponent implements OnInit {
  public course : Course = new Course();
  public participant : SignupCourseCommand = new SignupCourseCommand();

  public id: string;
  constructor(public formBuilder: FormBuilder,
              private courseService : CourseService,
              private router: Router,
              private toastrService: ToastrService,
              private activatedRoute: ActivatedRoute ) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.participant.courseGuid= params.id;
      this.loadCourse(this.participant.courseGuid);
    });
  }

  loadCourse(id){
    this.courseService.getCourseById(id)
      .pipe(finalize(() => {})
      ).subscribe((p : Course) => {
      this.course = p;
    }, error => {
      this.toastrService.error('Couldnt found course');
    });
  }

  onSubmit() {
    {
      this.courseService.signupCourse(this.participant)
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
}
