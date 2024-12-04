import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';  // To capture route parameters
import { HttpClient } from '@angular/common/http';  // For HTTP requests
import { FormsModule } from '@angular/forms';  // For ngModel binding
import { CommonModule } from '@angular/common';  // <-- Import CommonModule here

@Component({
  selector: 'app-praktik-page',
  standalone: true,  // Standalone component flag
  imports: [FormsModule, CommonModule],  // <-- Include CommonModule here
  templateUrl: './praktik-page.component.html',
  styleUrls: ['./praktik-page.component.css']
})
export class PraktikPageComponent implements OnInit {
  praktik: any[] = [];  // Holds the fetched praktik details from the API
  userNotes: string = '';  // Holds the user's notes input
  loading: boolean = true;
  error: string = '';
  courseName: string = ''; // Variable to hold course name
  courseId: string = ''; // Variable to hold course ID

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Fetch the courseId and courseName from the URL parameters
    this.route.paramMap.subscribe(params => {
      const courseId = params.get('courseId');
      const courseName = params.get('courseName');
      
      // Set the courseName and courseId if they exist
      if (courseId && courseName) {
        this.courseId = courseId;
        this.courseName = courseName;
        console.log(courseName);
        this.fetchPraktikDetails(courseId); // Fetch the praktik details using courseId
      } else {
        this.error = 'Course ID or Course Name not found in URL';
        this.loading = false;
      }
    });
  }

  // Fetch praktik details from API based on courseId
  fetchPraktikDetails(courseId: string): void {
    this.http.get<any[]>(`https://localhost:7164/api/InternshipGoal/GetAllInternshipGoalsBy/${courseId}`).subscribe(
      data => {
        this.praktik = data;  // Store fetched data
        this.loading = false;
      },
      (err) => {
        this.error = 'Failed to load praktik details';
        this.loading = false;
      }
    );
  }
}
