import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'

import { NgxMaskModule } from 'ngx-mask';

import { CustomerComponent } from './customer-component/customer.component';
import { CustomersComponent } from './customers-component/customers.component';
import { CustomerNotesComponent } from './customer-notes/customer-notes.component';
import { QuillDirective } from '../directives/quill.directive';
import { IconDirective } from '../directives/icon.directive';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgxMaskModule.forRoot(),
  ],
  exports: [
    CustomersComponent
  ],
  declarations: [
    CustomerComponent,
    CustomersComponent,
    CustomerNotesComponent,
    QuillDirective,
    IconDirective,
  ]
})
export class CustomerModule { }
