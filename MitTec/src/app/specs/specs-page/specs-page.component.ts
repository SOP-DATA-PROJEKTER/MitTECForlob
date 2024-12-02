import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';  // To get the route parameters

@Component({
  selector: 'app-specs-page',
  templateUrl: './specs-page.component.html',
  styleUrls: ['./specs-page.component.css']
})
export class SpecsPageComponent implements OnInit {
  educationName: string = '';  // To store the title from route parameters

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Retrieve the education name from route parameters
    this.route.params.subscribe(params => {
      this.educationName = params['educationName'];  // Fetch the education name
      console.log('Education Name:', this.educationName);  // You can use this variable in your template
    });
  }
}
