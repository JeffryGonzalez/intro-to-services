import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoursesComponent } from './courses.component';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './components/list/list.component';
import { StoreModule } from '@ngrx/store';
import { featureName, reducers } from './state';
import { HttpClientModule } from '@angular/common/http';
import { EffectsModule } from '@ngrx/effects';
import { CourseEffects } from './state/effects/course.effects';
import { EnrollComponent } from './components/enroll/enroll.component';
import { ReactiveFormsModule } from '@angular/forms';
const routes: Routes = [
  {
    path: '',
    component: CoursesComponent,
    children: [
      { path: 'list', component: ListComponent },
      { path: 'enroll/:id', component: EnrollComponent },
      { path: '**', redirectTo: 'list' },
    ],
  },
];

@NgModule({
  declarations: [CoursesComponent, ListComponent, EnrollComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    StoreModule.forFeature(featureName, reducers),
    EffectsModule.forFeature([CourseEffects]),
    HttpClientModule,
    ReactiveFormsModule,
  ],
  exports: [RouterModule],
})
export class CoursesModule {}
