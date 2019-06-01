import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from "@angular/core";
import {CoursesComponent} from "./courses/courses.component";
import {EditCourseComponent} from "./edit-course/edit-course";
import {SignupCourseComponent} from "./signup-course/signup-course";

const routes: Routes = [
  { path: 'course', component: CoursesComponent },
  { path: "course/:id", component: EditCourseComponent },
  { path: "course/signup/:id", component: SignupCourseComponent },
  { path: "add-course", component: EditCourseComponent },
  { path: '',  redirectTo: '/course', pathMatch: 'full' }
];

export const routingModule: ModuleWithProviders = RouterModule.forRoot(routes);
