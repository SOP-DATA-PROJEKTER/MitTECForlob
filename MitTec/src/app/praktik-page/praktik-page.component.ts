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
  email: string = '';  // Add email property to be passed
  goalsChecked: boolean[] = [];  // Array to track checkbox states for each goal

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const courseId = params.get('courseId');
      const courseName = params.get('courseName');
      this.email = 'emil'; // Set this dynamically if necessary

      if (courseId && courseName) {
        this.courseId = courseId;
        this.courseName = courseName;
        console.log('Course Name:', courseName);
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

        // Initialize goalsChecked array based on the number of goals
        this.goalsChecked = this.praktik.flatMap(item => this.splitDescription(item.description).map(() => false));  // Default to unchecked


        // After fetching praktik details, check if the goals should be pre-checked based on user and courseId
        this.checkGoalsStatus(courseId, this.email);
      },
      (err) => {
        this.error = 'Failed to load praktik details';
        this.loading = false;
      }
    );
  }

// Function to check if the checkboxes should be checked or not
checkGoalsStatus(courseId: string, email: string): void {
  // Fetch user-specific goal status (checked or unchecked)
  this.http.get<any>(`https://localhost:7164/api/InternshipGoalCheck/${courseId}/${email}`).subscribe(
    (goalStatus) => {
      // Debugging: Log the goal status we are receiving

      // Ensure the number of goals matches the number of checkbox states
      if (goalStatus && goalStatus.goals && goalStatus.goals.length === this.goalsChecked.length) {
        this.goalsChecked = goalStatus.goals;  // Update checkbox states based on the response
      } else {
        this.error = 'Goal status data does not match the expected number of goals';
      }
    },
    (err) => {
      this.error = 'Failed to load goal status for user';
    }
  );
}



  // Function to download notes as PDF
  downloadNotesAsPDF(): void {
    const doc = new jsPDF();
    doc.setFontSize(18);
    doc.text('Praktik Notes for ' + this.courseName, 20, 20);

    doc.setFontSize(12);
    doc.text('Your Notes:', 20, 30);
    doc.text(this.userNotes || 'No notes available', 20, 40);

    doc.save(`${this.courseName}-notes.pdf`);
  }

  // Method to split description by "*" and return an array of goals
  splitDescription(description: string): string[] {
    return description.split('*').map(goal => goal.trim()).filter(goal => goal);  // Split by "*" and trim extra spaces
  }

  // Method to check if all goals are checked
  areAllGoalsChecked(): boolean {
    return this.goalsChecked.every(checked => checked);  // Return true if all goals are checked
  }
}
