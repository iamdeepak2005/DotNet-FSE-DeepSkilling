import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentComponent } from './student.component';
import { CourseComponent } from './course.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  { path: 'students', component: StudentComponent, canActivate: [AuthGuard] },
  { path: 'courses', component: CourseComponent },
  { path: '', redirectTo: '/courses', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }