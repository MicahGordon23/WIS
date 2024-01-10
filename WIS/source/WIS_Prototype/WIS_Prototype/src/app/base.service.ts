import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export abstract class BaseService<T> {
  constructor(protected http: HttpClient) {
  }
  abstract getData(): Observable<ApiResult<T>>;
  abstract get(id: number): Observable<T>;
  abstract put(item: T): Observable<T>;
  abstract post(item: T): Observable<T>;
  protected getUrl(url: string) {
    return "/" + url;
  }
}

export interface ApiResult<T> {
  data: T[];
}
