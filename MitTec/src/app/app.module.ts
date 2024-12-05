import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule
import { AppComponent } from './app.component';
import { SubjPageComponent } from './subj-page/subj-page.component';  // Import your component

@NgModule({
  declarations: [
    AppComponent,
    SubjPageComponent  // Declare your component
  ],
  imports: [
    BrowserModule,
    HttpClientModule  // Include HttpClientModule here
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
