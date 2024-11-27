import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DatabaseService {
  private apiUrl = 'https://your-api-url.com/api'; // Replace with your actual API URL

  constructor(private http: HttpClient) {}

  // Fetch data for each entity with error handling
  getEducation(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/education`).pipe(
      catchError((error) => {
        console.error('Error fetching education data:', error);
        return throwError(() => new Error('Failed to load education data.'));
      })
    );
  }

  getProgress(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/progress`).pipe(
      catchError((error) => {
        console.error('Error fetching progress data:', error);
        return throwError(() => new Error('Failed to load progress data.'));
      })
    );
  }

  getNotes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/notes`).pipe(
      catchError((error) => {
        console.error('Error fetching notes data:', error);
        return throwError(() => new Error('Failed to load notes data.'));
      })
    );
  }

  getUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/users`).pipe(
      catchError((error) => {
        console.error('Error fetching users data:', error);
        return throwError(() => new Error('Failed to load users data.'));
      })
    );
  }

  getSpecs(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/specs`).pipe(
      catchError((error) => {
        console.error('Error fetching specs data:', error);
        return throwError(() => new Error('Failed to load specs data.'));
      })
    );
  }

  getSubjects(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/subjects`).pipe(
      catchError((error) => {
        console.error('Error fetching subjects data:', error);
        return throwError(() => new Error('Failed to load subjects data.'));
      })
    );
  }

  getAdminKeys(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/adminkeys`).pipe(
      catchError((error) => {
        console.error('Error fetching admin keys data:', error);
        return throwError(() => new Error('Failed to load admin keys data.'));
      })
    );
  }
}
