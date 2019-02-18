import { Component } from '@angular/core';
import { CustomersService } from '../services/customers.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  debounce: number;

  constructor(private customerService: CustomersService) {
    this.searchCustomers("");
  }

  onKey({ target: { value } }) {
    clearTimeout(this.debounce);
    this.debounce = setTimeout(() => {
      this.searchCustomers(value);
    }, 800);
  }

  private searchCustomers(searchTerms: string) {
    this.customerService.onCustomerSearch(searchTerms);
  }
}
