import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router'; // To access the route parameters
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-eud-page',
  standalone: true,
  imports: [CommonModule,RouterModule, HttpClientModule], // Import HttpClientModule here
  templateUrl: './education-page.component.html',
  styleUrls: ['./education-page.component.css']
})
export class EudPageComponent implements OnInit {
  title: string = ''; // Dynamic title
  educations: any[] = []; // To store fetched data
  loading: boolean = true; // To track loading state
  error: string = ''; // To store error message if any
  educationType: string = ''; // To store the type of education (EUD/EUX)

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Fetch education type from route parameters
    this.route.params.subscribe(params => {
      this.educationType = params['educationType']; // Get the educationType (EUD or EUX)
      this.setTitleBasedOnType(this.educationType); // Set the title dynamically
    });

    this.fetchEducations();
  }

  setTitleBasedOnType(educationType: string): void {
    if (educationType === 'eud') {
      this.title = 'EUD Uddannelser'; // Set title for EUD
    } else if (educationType === 'eux') {
      this.title = 'EUX Uddannelser'; // Set title for EUX
    } else {
      this.title = 'Uddannelser'; // Default title if the education type is not EUD or EUX
    }
  }

  fetchEducations(): void {
    const API_URL = 'https://localhost:7164/api/Education/GetAllEducations'; // Replace with your correct API URL
    this.http.get<any[]>(API_URL).subscribe(
      (data) => {
        this.educations = data;
        this.loading = false; // Data fetched, loading is false
        console.log('Data fetched:', this.educations);
      },
      (error) => {
        this.error = 'Error fetching data. Please try again later.';
        this.loading = false; // Stop loading on error
        console.error('Error fetching data:', error);
      }
    );
  }
}
