import { Event } from './../model/Event';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class EventService {
  baseUrl = 'https://localhost:5001/api/Event'

  constructor(private http: HttpClient) { }

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseUrl)
  }

  getEventsByTheme(theme: string): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.baseUrl}/${theme}/theme`)
  }

  getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.baseUrl}/${id}`)
  }

}
