import { Component } from '@angular/core';
import { CustomersService } from '../services/customers.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  debounce: number;
  isInputEmpty: boolean = true;
  isInputFocused: boolean = false;

  get inlinePlaceholder() {
    return this.isInputEmpty && !this.isInputFocused;
  }

  constructor(private customerService: CustomersService) {
    this.searchCustomers("");
  }

  onKey({ target: { value } }) {
    this.isInputEmpty = value.length === 0;
    clearTimeout(this.debounce);
    this.debounce = setTimeout(() => {
      this.searchCustomers(value);
    }, 800);
  }

  onFocus() {
    this.isInputFocused = true;
  }

  onBlur() {
    this.isInputFocused = false;
  }

  private searchCustomers(searchTerms: string) {
    this.customerService.onCustomerSearch(searchTerms);
  }
}
