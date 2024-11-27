import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DatabaseService } from '../database.service';
import { forkJoin, timer } from 'rxjs';
import { timeout, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-eux-page',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './eux-page.component.html',
  styleUrls: ['./eux-page.component.css']
})
export class EuxPageComponent implements OnInit {
  // Define the list dynamically
  items: { name: string; subItems: string[] }[] = [];
  searchText: string = '';
  filteredItems: { name: string; subItems: string[] }[] = [];
  expandedItem: string | null = null;
  isLoading: boolean = true; // Track loading state
  hasError: boolean = false; // Track error state

  private loadTimeout = 2 * 60 * 1000; // 2 minutes in milliseconds

  constructor(private databaseService: DatabaseService) {}

  ngOnInit(): void {
    this.loadData();
  }

  // Load data from both APIs and combine them
  loadData() {
    // Combine education and progress API calls
    forkJoin({
      education: this.databaseService.getEducation().pipe(timeout(this.loadTimeout)), // Timeout for education
      progress: this.databaseService.getProgress().pipe(timeout(this.loadTimeout)) // Timeout for progress
    })
      .subscribe({
        next: ({ education, progress }) => {
          // Combine education with progress data
          this.items = education.map(edu => ({
            name: edu.name, // Use "name" from education
            subItems: progress
              .filter(prog => prog.educationId === edu.id) // Match progress to education by ID
              .map(prog => prog.name) // Use "name" from progress
          }));
          this.filteredItems = [...this.items]; // Initially show all items
          this.isLoading = false; // Stop loading spinner
        },
        error: (err) => {
          console.error('Error loading data:', err);
          this.isLoading = false; // Stop loading spinner
          this.hasError = true; // Display error message
        }
      });
  }

  // Filter the list based on the search text
  filterList() {
    this.filteredItems = this.items.filter(item =>
      item.name.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }

  // Toggle the expanded state of an item
  toggleItem(itemName: string) {
    this.expandedItem = this.expandedItem === itemName ? null : itemName;
  }
}
