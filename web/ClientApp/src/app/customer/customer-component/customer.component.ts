import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Customer } from '../../types/customer';
import { IconDirective } from 'src/app/directives/icon.directive';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  @Input() customer: Customer;
  @Input() index: number;
  @Input() isFirst: boolean;

  acceptIcon:string = IconDirective.ACCEPT_ICON;
  cancelIcon:string = IconDirective.CANCEL_ICON;
  deleteIcon:string = IconDirective.DELETE_ICON;
  formCustomer: Customer = new Customer();

  constructor() { }

  ngOnInit() {
    Object.assign(this.formCustomer, this.customer);
  }
}
