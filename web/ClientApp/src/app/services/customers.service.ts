import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subscription, Subject, BehaviorSubject } from 'rxjs';
import { Customer } from '../types/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  private customers: Subject<Customer[]>;

  constructor(private http: HttpClient) {
    this.customers = new BehaviorSubject([]);
  }

  onCustomerSearch(searchTerms: string) {
    this.http.get<Customer[]>(`https://localhost:5001/api/customers?q=${searchTerms}`)
      .subscribe(customers => this.customers.next(customers));
  }

  getCustomers = (callback: (customers) => void): void => {
    this.customers.subscribe(customers => callback(customers));
  }
}
