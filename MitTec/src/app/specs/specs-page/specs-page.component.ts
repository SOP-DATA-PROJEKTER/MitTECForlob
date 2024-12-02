import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router'; // To access the route parameters
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-specs-page',
  standalone: true,
  imports: [CommonModule, HttpClientModule], // Import HttpClientModule for HTTP requests
  templateUrl: './specs-page.component.html',
  styleUrls: ['./specs-page.component.css']
})
export class SpecsPageComponent implements OnInit {
  educationId: number = 0;  // Store the education ID
  educationType: string = '';  // Store the education Type
  educationTitle: string = '';  // Store the education title  
  specsData: any[] = [];  // Store the specs data fetched
  loading: boolean = true;  // To track the loading state
  error: string = '';  // Store any error message

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Retrieve the route parameters when the component is initialized
    this.route.params.subscribe(params => {
      // Get the educationId and educationType from the URL
      this.educationId = +params['educationId'];  // Convert to number
      this.educationType = params['educationType'];  // Get education type as string
      this.educationTitle = params['educationTitle'];  // Get education title as string

      console.log('Education ID:', this.educationId, 'Education Type:', this.educationType);

      // After getting the parameters, fetch the specs related to the educationId
      this.fetchSpecsData();
    });
  }

  // Function to fetch the specs data based on educationId
  fetchSpecsData(): void {
    const API_URL = `https://localhost:7164/api/Specs/GetAllSpecsBy/${this.educationId}`; // Replace with your correct API URL
    this.http.get<any[]>(API_URL).subscribe(
      (data) => {
        // Filter the specs based on EuxAvailability and EducationType
        this.specsData = data.filter(spec => {
          // If EuxAvailability is 0, only show for 'eud' type
          if (spec.euxAvailability  === false) {
            return this.educationType === 'eud';
          }
          // If EuxAvailability is 1, show on both education types
          return spec.euxAvailability  === true;
        });
  
        this.loading = false;  // Data fetched, stop loading
        console.log('Filtered Specs Data:', this.specsData);  // Log the filtered data
      },
      (error) => {
        this.error = 'Error fetching specs data. Please try again later.';  // Handle error
        this.loading = false;  // Stop loading on error
        console.error('Error fetching data:', error);  // Log error
      }
    );
  }
}