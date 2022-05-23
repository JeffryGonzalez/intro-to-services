import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, tap } from 'rxjs';
import { selectCourseById } from '../../state';
import { CoursesEntity } from '../../state/reducers/courses.reducer';

@Component({
  selector: 'app-enroll',
  templateUrl: './enroll.component.html',
  styleUrls: ['./enroll.component.css'],
})
export class EnrollComponent implements OnInit {
  course$!: Observable<CoursesEntity | undefined>;
  id!: string;
  form = this.formBuilder.group({
    name: [''],
    dateOfCourse: [''],
    course: [''],
  });
  constructor(
    private route: ActivatedRoute,
    private store: Store,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const id = params.get('id');
      this.id = id!;
      this.course$ = this.store
        .select(selectCourseById(id!))
        .pipe(tap((c) => this.courseId?.setValue(c?.id)));
    });
  }

  get courseId() {
    return this.form.get('course');
  }
  submit() {
    console.log(this.form.value);
  }
}
