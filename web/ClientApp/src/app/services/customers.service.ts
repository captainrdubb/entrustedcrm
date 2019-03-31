import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
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
    this.http.post('https://localhost:5001/api/customers', customer).subscribe({
      error: err => console.log(err.message || err),
    });
  }

  deleteCustomer(customer: Customer): void {
    this.http
      .delete(`https://localhost:5001/api/customers/${customer.key}`)
      .subscribe({
        error: err => console.log(err.message || err),
      });
  }

  onCustomerSearch(searchTerms: string) {
    this.http
      .get<Customer[]>(`https://localhost:5001/api/customers?q=${searchTerms}`)
      .subscribe({
        next: customers => this.customers.next(customers),
        error: err => console.log(err.message || err),
      });
  }

  getCustomers = (callback: (customers) => void): void => {
    this.customers.subscribe(customers => callback(customers));
  };
}
