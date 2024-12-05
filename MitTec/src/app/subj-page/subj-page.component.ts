import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router'; 
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-subj-page',
  imports: [CommonModule, RouterModule],
  standalone: true,
  templateUrl: './subj-page.component.html',
  styleUrls: ['./subj-page.component.css']
})
export class SubjPageComponent implements OnInit {
  subj: any[] = []; // Array to hold multiple subjects
  loading: boolean = true;
  error: string = '';
  subjId: number = 0;
  subjTitle: string = '';

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Subscribe to route parameters and get 'courseId' and 'courseTitle'
    this.route.paramMap.subscribe(params => {
      const subjId = params.get('courseId');
      const subjTitle = params.get('courseTitle');
      
      // Set subjTitle and subjId
      if (subjTitle) {
        this.subjTitle = subjTitle;
      }

      if (subjId) {
        this.fetchSubjDetails(subjId, subjTitle);
      }
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
        this.subj = data.map(subject => ({
          ...subject,
          showMore: false,  // Initially set showMore to false for each subject
          isTruncated: subject.description.length > 100,  // Check if description is long enough to be truncated
        }));
        this.loading = false;
      },
      (error) => {
        this.error = 'Error fetching subject details. Please try again later.';
        this.loading = false;
      }
    );
  }

  toggleDescription(subject: any): void {
    // Collapse all other cards first
    this.subj.forEach(s => {
      if (s !== subject) {
        s.showMore = false;
      }
    });

    // Toggle the clicked card
    subject.showMore = !subject.showMore;
  }
}
