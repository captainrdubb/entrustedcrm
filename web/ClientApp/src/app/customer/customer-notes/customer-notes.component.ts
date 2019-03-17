import { Component, OnInit, Input } from '@angular/core';
import { CustomerNote } from 'src/app/types/customerNote';
import { CustomerNotesService } from 'src/app/services/customer-notes.service';
import { IconDirective } from 'src/app/directives/icon.directive';
import { CustomerNoteForm } from 'src/app/types/customerNoteForm';

@Component({
  selector: 'app-customer-notes',
  templateUrl: './customer-notes.component.html',
  styleUrls: ['./customer-notes.component.css'],
})
export class CustomerNotesComponent implements OnInit {
  @Input() customerKey: string;

  newNote: CustomerNoteForm;
  plusIcon: string = IconDirective.CREATE_ICON;
  editIcon: string = IconDirective.EDIT_ICON;
  saveEditIcon: string = IconDirective.ACCEPT_ICON;
  notes: CustomerNoteForm[];

  constructor(private customerNotesService: CustomerNotesService) {}

  onEditClick(note: CustomerNoteForm) {
    note.editable = !note.editable;
  }

  onSaveEditClick(note: CustomerNoteForm) {
    if (note === this.newNote) this.newNote = undefined;
    note.editable = !note.editable;
  }

  onNewNoteClick() {
    if (this.newNote) return;

    this.newNote = new CustomerNoteForm();
    this.newNote.createdOn = new Date();
    this.newNote.createdBy = {
      key: '9cf080d9-b06c-4fc6-9091-743b061b2066',
      givenName: 'joel',
      familyName: 'wills',
    };
    this.newNote.editable = true;
    this.notes.push(this.newNote);
  }

  ngOnInit() {
    this.customerNotesService
      .getCustomerNotes(this.customerKey)
      .subscribe((notes: CustomerNote[]) => {
        this.notes = notes.map((note: CustomerNote) => {
          return Object.assign(new CustomerNoteForm(), note);
        });
      });
  }
}
