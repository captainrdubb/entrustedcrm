import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerNote } from '../types/customerNote';

@Injectable({
  providedIn: 'root'
})
export class CustomerNotesService {

  constructor(private http: HttpClient) { }

  getCustomerNotes = (customerKey: string): Observable<CustomerNote[]> => this.http.get<CustomerNote[]>(`https://localhost:5001/api/notes?customerKey=${customerKey}`);
}
