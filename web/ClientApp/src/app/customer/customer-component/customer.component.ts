import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Customer } from '../../types/customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  @Input() customer: Customer;
  @Input() index: number;
  @Input() isFirst: boolean;

  formCustomer: Customer = new Customer();

  constructor() { }

  ngOnInit() {
     Object.assign(this.formCustomer, this.customer);
  }
}
