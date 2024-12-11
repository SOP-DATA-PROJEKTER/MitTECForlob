import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router'; // To access the route parameters
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-specs-page',
  standalone: true,
  imports: [CommonModule, RouterModule, HttpClientModule], // Import HttpClientModule for HTTP requests
  templateUrl: './course-page.component.html',
  styleUrls: ['./course-page.component.css']
})
export class CoursePageComponent implements OnInit {
  specsId: number = 0;  // This will hold the specsId from the URL
  specsTitle: string = '';  // This will hold the specsTitle from the URL
  courseData: any[] = [];  // This will store the courses fetched from the API
  loading: boolean = true;  // To track the loading state
  error: string = '';  // To store any error message

  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  ngOnInit(): void {
    // Retrieve the specsId from the route parameters
    this.route.params.subscribe(params => {
      this.specsId = +params['specsId'];  // Convert the param to number
      this.specsTitle = params['specsTitle'];  // Get the specsTitle from the
      console.log('Course details for specsId:', this.specsId + ' - specsTitle: ' + this.specsTitle);  // Log the specsId and specsTitle

      // Call the API to fetch courses based on specsId
      this.fetchCourses();
    });
  }

  // Function to fetch courses based on the specsId
  fetchCourses(): void {
    const API_URL = `https://localhost:7164/api/Course/GetAllCoursesBy/${this.specsId}`;  // API endpoint with dynamic specsId
    this.http.get<any[]>(API_URL).subscribe(
      (data) => {
        // Process and intertwine the courses after fetching
        this.courseData = this.organizeAndIntertwineCourses(data);  // Call the organizeAndIntertwineCourses function
        this.loading = false;  // Stop loading when data is fetched
        console.log('Courses fetched and intertwined:', this.courseData);  // Log the fetched and intertwined data
      },
      (error) => {
        this.error = 'Error fetching course data. Please try again later.';  // Handle error
        this.loading = false;  // Stop loading on error
        console.error('Error fetching data:', error);  // Log the error
      }
    );
  }

  // Method to generate the router link dynamically
  getRouterLink(course: any): string[] {
    // Check if courseName contains 'SOP' (for PraktikForløb) or 'H' (for HovedForløb)
    if (course.courseName && course.courseName.toLowerCase().startsWith('sop')) {
      // Return router link for 'praktik' route
      return ['/praktik', course.id, course.courseName]; // Navigate to the PraktikPageComponent
    }
    else if (course.courseName && course.courseName.toLowerCase().startsWith('h')) {
      // Return router link for 'subj' route
      return ['/subj', course.id, course.courseName]; // Navigate to the SubjPageComponent
    } else {
      return ['/default-page']; // Fallback route if neither condition is met
    }
  }

  organizeAndIntertwineCourses(courses: any[]): any[] {
    const praktikForlob: any[] = [];
    const hovedForlob: any[] = [];

    // Split courses into categories based on courseName (praktikforløb or hovedeforløb)
    courses.forEach(course => {
      const courseNameLower = (course.courseName?.toLowerCase() || '').trim();  // Convert to lowercase for easier comparison

      // Check if the course name starts with 'sop' for PraktikForløb or 'h' for HovedForløb
      if (courseNameLower.startsWith('sop')) {
        praktikForlob.push(course);  // Add to PraktikForløb
      } else if (courseNameLower.startsWith('h')) {
        hovedForlob.push(course);  // Add to HovedForløb
      }
    });

    console.log('praktikForlob:', praktikForlob);  // Check the split data
    console.log('hovedForlob:', hovedForlob);  // Check the split data

    // Sort the courses based on their number after the prefix (e.g., SOP1, H1, SOP2, H2)
    const extractNumber = (name: string): number => {
      const match = name.match(/\d+/);  // Match all digits in the name (e.g., 'SOP1' -> 1, 'H2' -> 2)
      return match ? parseInt(match[0], 10) : 0;  // Extract the number from the name and parse it
    };

    // Sort both arrays by the number after the prefix
    praktikForlob.sort((a, b) => extractNumber(a.courseName) - extractNumber(b.courseName));
    hovedForlob.sort((a, b) => extractNumber(a.courseName) - extractNumber(b.courseName));

    // Intertwine the courses by alternating between PraktikForløb and HovedForløb
    const intertwinedCourses: any[] = [];
    const maxLength = Math.max(praktikForlob.length, hovedForlob.length);

    // Alternate between praktikforløb and hovedeforløb courses
    for (let i = 0; i < maxLength; i++) {
      if (i < praktikForlob.length) {
        intertwinedCourses.push(praktikForlob[i]);
      }
      if (i < hovedForlob.length) {
        intertwinedCourses.push(hovedForlob[i]);
      }
    }

    console.log('Intertwined courses:', intertwinedCourses);  // Verify the final output
    return intertwinedCourses;
  }
}
