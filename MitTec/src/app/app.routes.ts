import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EudPageComponent } from './education-page/education-page.component';
import { SpecsPageComponent } from './specs-page/specs-page.component';
import { CoursePageComponent } from './course-page/course-page.component';
import { LoginComponent } from './login/login.component';
import { SubjPageComponent } from './subj-page/subj-page.component';
import { PraktikPageComponent } from './praktik-page/praktik-page.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'education/:educationType', component: EudPageComponent }, // EUD page
  { path: 'specs/:educationId/:educationType/:educationTitle', component: SpecsPageComponent },
  { path: 'course/:specsId/:specsTitle', component: CoursePageComponent },
  { path: 'subj/:courseId/:courseTitle', component: SubjPageComponent },
  { path: 'praktik/:courseId/:courseName', component: PraktikPageComponent },
  { path: 'login', component: LoginComponent },  // Login page 
  { path: '', redirectTo: '/home', pathMatch: 'full' } // Default route
  // Add other routes here as needed
];