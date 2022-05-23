import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import * as fromCourses from './reducers/courses.reducer';
export const featureName = 'featureCourses';

export interface CoursesState {
  courses: fromCourses.CoursesState;
}

export const reducers: ActionReducerMap<CoursesState> = {
  courses: fromCourses.reducer,
};

const selectFeature = createFeatureSelector<CoursesState>(featureName);

const selectCoursesBranch = createSelector(selectFeature, (f) => f.courses);

const {
  selectAll: selectAllCoursesArray,
  selectEntities: selectCourseEntities,
} = fromCourses.adapter.getSelectors(selectCoursesBranch);

export const selectAllCourses = selectAllCoursesArray;

export const selectCourseById = (id: string) =>
  createSelector(selectCourseEntities, (entities) => entities[id]);
