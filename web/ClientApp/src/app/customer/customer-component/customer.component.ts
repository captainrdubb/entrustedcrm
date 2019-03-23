import { Component, OnInit, Input } from '@angular/core';
import { IconDirective } from 'src/app/directives/icon.directive';
import { CustomerStatus } from 'src/app/types/customerStatus';
import { CustomerForm } from 'src/app/types/customerForm';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent {
  @Input() customer: CustomerForm;
  @Input() index: number;
  @Input() expand: boolean;

  acceptIcon: string = IconDirective.ACCEPT_ICON;
  cancelIcon: string = IconDirective.CANCEL_ICON;
  deleteIcon: string = IconDirective.DELETE_ICON;
  statuses: CustomerStatus[] = [
    CustomerStatus.Undefined,
    CustomerStatus.Current,
    CustomerStatus.NonActive,
    CustomerStatus.Prospective
  ];

  constructor() {
    if (!this.customer) this.customer = this.createNewCustomerShell();
  }

  createNewCustomerShell(): CustomerForm {
    let customer = new CustomerForm();
    customer.status = CustomerStatus.Undefined;
    customer.isNewCustomer = true;
    return customer;
  }
}
