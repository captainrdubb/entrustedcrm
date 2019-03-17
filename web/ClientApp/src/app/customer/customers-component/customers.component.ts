import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../../services/customers.service';
import { Customer } from '../../types/customer';
import { IconDirective } from 'src/app/directives/icon.directive';
import { CustomerStatus } from 'src/app/types/customerStatus';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[];
  createCustomer: boolean = false;
  plusIcon: string = IconDirective.CREATE_ICON;

  constructor(private customerService: CustomersService) { }

  ngOnInit() {
    this.customerService.getCustomers((customers) => this.customers = customers);
  }

  createNewCustomerShell(): Customer {
    let customer = new Customer();   
    customer.status = CustomerStatus.Undefined;
    return customer;
  }

  onNewCustomerClick(): void {
    this.createCustomer = !this.createCustomer;
  }
}
