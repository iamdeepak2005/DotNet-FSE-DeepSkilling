import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { StudentComponent } from './student.component';
import { CourseComponent } from './course.component';

@NgModule({
  declarations: [
    StudentComponent,
    CourseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [StudentComponent]
})
export class AppModule { }