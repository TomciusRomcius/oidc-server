import ApiResponseModel from '@models/api-response.model';
import { map, Observable } from 'rxjs';
import ErrorResponseModel from '../models/error-response.model';

export function responseToModel<T>(observable: Observable<ApiResponseModel<T>>) {
  return observable.pipe(map((res) => res.data));
}

export function responseToError(response: unknown) {
  const res = response as ErrorResponseModel;
  return res.error ?? 'Unknown error';
}
