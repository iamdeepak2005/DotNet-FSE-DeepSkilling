import { Component, OnInit } from '@angular/core';

export interface Student {
  id: number;
  name: string;
  course: string;
}

@Component({
  selector: 'app-students',
  template: `
    <div style="padding: 20px; color: white;">
      <h3>Students Directory</h3>
      <ul>
        <li *ngFor="let s of students">
          {{ s.name }} enrolled in <strong>{{ s.course }}</strong> (ID: {{ s.id }})
        </li>
      </ul>
    </div>
  `
})
export class StudentComponent implements OnInit {
  students: Student[] = [];

  ngOnInit() {
    this.students = [
      { id: 1, name: 'Amit Sharma', course: '.NET Full Stack' },
      { id: 2, name: 'Deepa Nair', course: 'Angular UI Architecture' }
    ];
  }
}