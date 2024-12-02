import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EudPageComponent } from './education-page/education-page.component';
import { SpecsPageComponent } from './specs/specs-page/specs-page.component';
import { LoginComponent } from './login/login.component';


export const routes: Routes = [

    { path: '', component: HomeComponent },
    { path: 'education/:educationType', component: EudPageComponent }, // EUD page
    { path: 'specs/:educationName', component: SpecsPageComponent },
    { path: 'login', component: LoginComponent }  // Login page 
    // Add other routes here as needed
    
  ];