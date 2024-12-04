import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router'; // To access the route parameters
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-specs-page',
  standalone: true,
  imports: [CommonModule,RouterModule, HttpClientModule], // Import HttpClientModule for HTTP requests
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
  
  organizeAndIntertwineCourses(courses: any[]): any[] {
    const praktikForlob: any[] = [];
    const hovedForlob: any[] = [];
  
    // Split courses into categories based on courseName (praktikforløb or hovedeforløb)
    courses.forEach(course => {
      const courseNameLower = course.courseName?.toLowerCase() || '';  // Convert to lowercase for easier comparison
      course.courseName = courseNameLower;  // Ensure courseName is lowercase for consistency
  
      if (courseNameLower.startsWith('praktikforløb')) {
        praktikForlob.push(course);
      } else if (courseNameLower.startsWith('hovedeforløb')) {
        hovedForlob.push(course);
      }
    });
  
    console.log('praktikForlob:', praktikForlob);  // Check the split data
    console.log('hovedForlob:', hovedForlob);  // Check the split data
  
    // Sort the courses based on their number after the dash (e.g., PraktikForløb-1, HovedeForløb-1, etc.)
    const extractNumber = (name: string): number => {
      const match = name.match(/\d+/);
      return match ? parseInt(match[0], 10) : 0;  // Extract the number from course name
    };
  
    // Sort both arrays by the number after the dash
    praktikForlob.sort((a, b) => extractNumber(a.courseName) - extractNumber(b.courseName));
    hovedForlob.sort((a, b) => extractNumber(a.courseName) - extractNumber(b.courseName));
  
    // Intertwine the courses by alternating between PraktikForløb and HovedeForløb
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
  getRouterLink(course: any): string[] {
    // Check if courseName contains 'praktikforløb'
    if (course.courseName && course.courseName.toLowerCase().includes('praktikforløb')) {
      return ['/praktik', course.id, course.courseName]; // Navigate to the praktik page
    }
    // Check if courseName contains 'hovedeforløb'
    else if (course.courseName && course.courseName.toLowerCase().includes('hovedeforløb')) {
      return ['/subj', course.id, course.courseName]; // Navigate to the subj page
    } else {
      return ['/default-page']; // Fallback route if neither condition is met
    }
  }
  
  
}
