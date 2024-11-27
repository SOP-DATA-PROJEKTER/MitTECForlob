import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-eud-page',
  standalone: true,
  imports: [CommonModule, HttpClientModule], // Import necessary modules
  templateUrl: './eud-page.component.html',
  styleUrls: ['./eud-page.component.css'] // Corrected property name
})
export class EudPageComponent implements OnInit {
  title = 'Education List';
  educations: any[] = []; // To store fetched data

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchEducations();
  }

  fetchEducations(): void {
    const API_URL = 'https://localhost:7164/api/Education/GetAllEducations';
    this.http.get<any[]>(API_URL).subscribe(
      (data) => {
        this.educations = data;
        console.log('Data fetched:', this.educations);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }
}
