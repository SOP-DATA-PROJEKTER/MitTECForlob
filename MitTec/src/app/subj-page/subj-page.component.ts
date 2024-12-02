import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router'; // To access the route parameters
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-subj-page',
  imports: [CommonModule, RouterModule, HttpClientModule], // Import HttpClientModule here
  standalone: true,
  templateUrl: './subj-page.component.html',
  styleUrls: ['./subj-page.component.css']
})
export class SubjPageComponent implements OnInit {
  subj: any[] = []; // Now it's an array to hold multiple subjects
  loading: boolean = true;
  error: string = '';

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const subjId = params.get('courseId');
      const subjTitle = params.get('courseTitle');
      this.fetchSubjDetails(subjId, subjTitle);
    });
  }

  fetchSubjDetails(subjId: string | null, subjTitle: string | null): void {
    if (!subjId || !subjTitle) {
      this.error = 'Invalid subject details';
      this.loading = false;
      return;
    }

    const API_URL = `https://localhost:7164/api/Subj/GetAllSubjBy/${subjId}`;
    this.http.get<any[]>(API_URL).subscribe(
      (data) => {
        console.log('Fetched data:', data); // Log the fetched data to the console
        this.subj = data; // Store the fetched subjects in the subj array
        this.loading = false;
      },
      (error) => {
        this.error = 'Error fetching subject details. Please try again later.';
        this.loading = false;
      }
    );
  }
}
