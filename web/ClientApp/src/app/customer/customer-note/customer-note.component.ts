import { Component, OnInit, Input } from '@angular/core';
import { CustomerNote } from 'src/app/types/customerNote';
import { CustomerNotesService } from 'src/app/services/customer-notes.service';

@Component({
  selector: 'app-customer-note',
  templateUrl: './customer-note.component.html',
  styleUrls: ['./customer-note.component.css']
})
export class CustomerNoteComponent implements OnInit {

  @Input() customerKey: string;

  notes: CustomerNote[];

  constructor(private customerNotesService: CustomerNotesService) { }

  ngOnInit() {
    this.customerNotesService.getCustomerNotes(this.customerKey)
      .subscribe((notes: CustomerNote[]) => {
        this.notes = notes;
      });
  }

}
