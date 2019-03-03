import { Component, OnInit, Input } from '@angular/core';
import { Customer } from '../../types/customer';
import { IconDirective } from 'src/app/directives/icon.directive';
import { CustomerStatus } from 'src/app/types/customerStatus';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  @Input() customer: Customer;
  @Input() index: number;
  @Input() expand: boolean;

  acceptIcon:string = IconDirective.ACCEPT_ICON;
  cancelIcon:string = IconDirective.CANCEL_ICON;
  deleteIcon:string = IconDirective.DELETE_ICON;
  statuses: CustomerStatus[] = [CustomerStatus.Current, CustomerStatus.NonActive, CustomerStatus.Prospective];
  formCustomer: Customer = new Customer();

  constructor() { }

  ngOnInit() {
    Object.assign(this.formCustomer, this.customer);
  }
}
