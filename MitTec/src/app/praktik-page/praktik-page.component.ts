import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { jsPDF } from 'jspdf';  // <-- Import jsPDF here

@Component({
  selector: 'app-praktik-page',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './praktik-page.component.html',
  styleUrls: ['./praktik-page.component.css']
})
export class PraktikPageComponent implements OnInit {
  praktik: any[] = [];
  userNotes: string = '';
  loading: boolean = true;
  error: string = '';
  courseName: string = '';
  courseId: string = '';

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const courseId = params.get('courseId');
      const courseName = params.get('courseName');

      if (courseId && courseName) {
        this.courseId = courseId;
        this.courseName = courseName;
        console.log(courseName);
        this.fetchPraktikDetails(courseId);
      } else {
        this.error = 'Course ID or Course Name not found in URL';
        this.loading = false;
      }
    });
  }

  fetchPraktikDetails(courseId: string): void {
    this.http.get<any[]>(`https://localhost:7164/api/InternshipGoal/GetAllInternshipGoalsBy/${courseId}`).subscribe(
      data => {
        this.praktik = data;
        this.loading = false;
      },
      (err) => {
        this.error = 'Failed to load praktik details';
        this.loading = false;
      }
    );
  }

  // Function to download notes as PDF
  downloadNotesAsPDF(): void {
    const doc = new jsPDF();

    // Title
    doc.setFontSize(18);
    doc.text('Praktik Notes for ' + this.courseName, 20, 20);

    // Notes Section
    doc.setFontSize(12);
    doc.text('Your Notes:', 20, 30);
    doc.text(this.userNotes || 'No notes available', 20, 40);

    // Download PDF
    doc.save(`${this.courseName}-notes.pdf`);
  }
}
