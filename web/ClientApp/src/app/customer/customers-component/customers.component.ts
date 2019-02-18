import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../../services/customers.service';
import { Customer } from '../../types/customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[];

  constructor(private customerService: CustomersService) { }

  ngOnInit() {
    this.customerService.getCustomers((customers) => this.customers = customers);
  }
}
