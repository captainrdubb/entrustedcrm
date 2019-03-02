import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../../services/customers.service';
import { Customer } from '../../types/customer';
import { IconDirective } from 'src/app/directives/icon.directive';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[];
  plusIcon: string = IconDirective.PLUS_ICON;

  constructor(private customerService: CustomersService) { }

  ngOnInit() {
    this.customerService.getCustomers((customers) => this.customers = customers);
  }

  onNewCustomerClick(): void {

  }
}
