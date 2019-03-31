import { Component, OnInit, Input } from '@angular/core';
import { CustomerNote } from 'src/app/types/customerNote';
import { CustomerNotesService } from 'src/app/services/customer-notes.service';
import { IconDirective } from 'src/app/directives/icon.directive';
import { CustomerNoteForm } from 'src/app/types/customerNoteForm';
import { not } from '@angular/compiler/src/output/output_ast';

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
  cancelEditIcon: string = IconDirective.CANCEL_ICON;
  deleteNoteIcon: string = IconDirective.DELETE_ICON;
  notes: CustomerNoteForm[];

  constructor(private customerNotesService: CustomerNotesService) {}

  onEditClick(note: CustomerNoteForm) {
    note.editable = !note.editable;
  }

  onDeleteNoteClick(note: CustomerNoteForm) {
    this.removeNote(note);
    this.customerNotesService.deleteCustomerNote(note.key);
  }

  onSaveEditClick(note: CustomerNoteForm) {
    note.editable = !note.editable;
    if (note === this.newNote) this.newNote = undefined;
  }

  onCancelEditClick(note: CustomerNoteForm) {
    note.editable = !note.editable;
    if (note === this.newNote) {
      this.newNote = undefined;
      this.removeNote(note);
    }
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

  removeNote(note: CustomerNoteForm) {
    const index = this.notes.indexOf(note);
    if (index !== -1) this.notes.splice(index, 1);
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
