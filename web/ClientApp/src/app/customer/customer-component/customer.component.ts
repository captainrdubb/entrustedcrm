import { Component, OnInit, Input } from '@angular/core';
import { IconDirective } from 'src/app/directives/icon.directive';
import { CustomerStatus } from 'src/app/types/customerStatus';
import { CustomerForm } from 'src/app/types/customerForm';
import { Customer } from 'src/app/types/customer';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  @Input() customer: Customer;
  @Input() index: number;
  @Input() expand: boolean;

  customerFormModel: CustomerForm;

  acceptIcon: string = IconDirective.ACCEPT_ICON;
  cancelIcon: string = IconDirective.CANCEL_ICON;
  deleteIcon: string = IconDirective.DELETE_ICON;

  statuses: CustomerStatus[] = [
    CustomerStatus.Undefined,
    CustomerStatus.Current,
    CustomerStatus.NonActive,
    CustomerStatus.Prospective
  ];

  ngOnInit(): void {
    if (this.customer)
      this.customerFormModel = Object.assign(new CustomerForm(), this.customer);
    else this.customerFormModel = this.createNewCustomerShell();
  }

  createNewCustomerShell(): CustomerForm {
    let form = new CustomerForm();
    form.status = CustomerStatus.Undefined;
    form.isNewCustomer = true;
    return form;
  }

  onCancelEditClick(customerFrom: NgForm) {
    customerFrom.resetForm(this.customer);    
  }
}
