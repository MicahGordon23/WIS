import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Source } from './source';

@Injectable({
  providedIn: 'root'
})
export class SourceService {
  url: string;
  constructor (private httpClient: HttpClient) {
    this.url = "api/Sources"
  }

  getSources(): Observable<Source[]> {
    return this.httpClient.get<Source[]>(this.url);
  }
}
