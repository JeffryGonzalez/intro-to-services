import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { CoursesCommands } from './state/actions/courses.actions';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css'],
})
export class CoursesComponent implements OnInit {
  constructor(store: Store) {
    store.dispatch(CoursesCommands.LoadCourses());
  }

  ngOnInit(): void {}
}
