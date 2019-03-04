import { Component, OnInit, Input } from '@angular/core';
import { CustomerNote } from 'src/app/types/customerNote';
import { CustomerNotesService } from 'src/app/services/customer-notes.service';
import { IconDirective } from 'src/app/directives/icon.directive';

@Component({
  selector: 'app-customer-notes',
  templateUrl: './customer-notes.component.html',
  styleUrls: ['./customer-notes.component.css']
})
export class CustomerNotesComponent implements OnInit {

  @Input() customerKey: string;

  plusIcon:string = IconDirective.CREATE_ICON;
  editIcon: string = IconDirective.EDIT_ICON;
  notes: CustomerNote[];

  constructor(private customerNotesService: CustomerNotesService) { }

  onEditClick(note: CustomerNote) {
    note.editable = !note.editable;
  }

  ngOnInit() {
    this.customerNotesService.getCustomerNotes(this.customerKey)
      .subscribe((notes: CustomerNote[]) => {
        this.notes = notes;
      });
  }
}
