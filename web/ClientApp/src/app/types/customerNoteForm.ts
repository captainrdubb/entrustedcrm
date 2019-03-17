import { EntrustedUser } from './entrustedUser';

export class CustomerNoteForm {
  customerKey: string;
  createdBy: EntrustedUser;
  createdOn: Date;
  updatedBy: EntrustedUser;
  updatedOn: Date;
  text: string;
  editable: boolean;
  onTextChange: ($event: any) => string;
}
