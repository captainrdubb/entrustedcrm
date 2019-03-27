import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Customer } from '../types/customer';

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  private customers: BehaviorSubject<Customer[]>;

  constructor(private http: HttpClient) {
    this.customers = new BehaviorSubject([]);
  }

  createCustomer(customer: Customer): void {
    this.http
      .post('https://localhost:5001/api/customers', customer)
      .pipe(catchError(val => of(val)))
      .subscribe(result => console.log(result.error || result));
  }

  onCustomerSearch(searchTerms: string) {
    this.http
      .get<Customer[]>(`https://localhost:5001/api/customers?q=${searchTerms}`)
      .subscribe(customers => this.customers.next(customers));
  }

  getCustomers = (callback: (customers) => void): void => {
    this.customers.subscribe(customers => callback(customers));
  };
}
