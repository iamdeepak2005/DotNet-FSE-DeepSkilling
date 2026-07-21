import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-courses',
  template: `
    <div style="padding: 20px; color: white;">
      <h3>Available Courses</h3>
      <table border="1" cellpadding="10" style="border-collapse: collapse; border-color: #334155;">
        <tr style="background-color: #334155;">
          <th>Course Name</th>
          <th>Duration</th>
        </tr>
        <tr>
          <td>.NET Full Stack Engineer</td>
          <td>8 Weeks</td>
        </tr>
        <tr>
          <td>Angular UI Development</td>
          <td>4 Weeks</td>
        </tr>
      </table>
    </div>
  `
})
export class CourseComponent {}