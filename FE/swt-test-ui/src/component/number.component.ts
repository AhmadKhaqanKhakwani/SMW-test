import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-number-operations',
  templateUrl: './number.component.html',
  styleUrls: ['./number.component.css'],
  standalone: true,  // Mark the component as standalone
  imports: [CommonModule, FormsModule]  // Import CommonModule and FormsModule directly here
})
export class NumberOperationsComponent {
  baseURL ="https://localhost:7228";
  numberToAdd: number = 0;
  activeDataStructure: string = 'SortedSet';
  result: string = "";

  constructor(private http: HttpClient) {}

  addNumber() {
    this.http.post(`${this.baseURL}/api/numbers/add`, this.numberToAdd)
      .subscribe({
        next: () => {
          this.result = `Number ${this.numberToAdd} added successfully.`;
          this.numberToAdd = 0; // clear the input after adding
        },
        error: error => console.error('There was an error!', error)
      });
  }

  getMax() {
    this.http.get<number>(`${this.baseURL}/api/numbers/max`)
      .subscribe({
        next: data => this.result = `Maximum: ${data}`,
        error: error => this.result = 'Error retrieving maximum number'
      });
  }

  getMin() {
    this.http.get<number>(`${this.baseURL}/api/numbers/min`)
      .subscribe({
        next: data => this.result = `Minimum: ${data}`,
        error: error => this.result = 'Error retrieving minimum number'
      });
  }

  onChange() {
    const payload = { dataStructure: this.activeDataStructure }; // Make sure to send an object if the backend expects one
  this.http.post(`${this.baseURL}/api/numbers/set-datastructure`, payload, {
    headers: { 'Content-Type': 'application/json' } // Ensure correct Content-Type is set
  }).subscribe({
    next: response => console.log(response),
    error: error => console.error('Error setting data structure:', error)
  });
  }

}
