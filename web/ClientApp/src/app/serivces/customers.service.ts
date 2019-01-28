import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../types/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private http: HttpClient) { }

  getCustomers = (): Observable<Customer[]> => this.http.get<Customer[]>("https://localhost:5001/api/customers");
}
