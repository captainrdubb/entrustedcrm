import { Component, OnInit, Input } from '@angular/core';
import { Customer } from '../types/customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  @Input() customer: Customer;
  @Input() index: number;
  @Input() isFirst: boolean;

  constructor() { }

  ngOnInit() {
  }

}
