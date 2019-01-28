import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../serivces/customers.service';
import { Customer } from '../types/customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[];

  constructor(private customerService: CustomersService) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe((customers: Customer[]) => {
      this.customers = customers;
    });
  }

}
