import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { selectAllCourses } from '../../state';
import { CoursesEntity } from '../../state/reducers/courses.reducer';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit {
  courses$!: Observable<CoursesEntity[]>;
  constructor(private store: Store) {}

  ngOnInit(): void {
    this.courses$ = this.store.select(selectAllCourses);
  }
}
