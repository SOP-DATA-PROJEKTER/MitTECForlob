import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EudPageComponent } from './eud-page/eud-page.component';
import { EuxPageComponent } from './eux-page/eux-page.component';
import { LoginComponent } from './login/login.component';


export const routes: Routes = [

    { path: '', component: HomeComponent },
    { path: 'eud', component: EudPageComponent }, // EUD page
    { path: 'eux', component: EuxPageComponent }, // EUX page
    { path: 'login', component: LoginComponent }  // Login page 
    // Add other routes here as needed
    
  ];