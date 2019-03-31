import { EntrustedUser } from './entrustedUser';

export class CustomerNoteForm {
  key: string;
  customerKey: string;
  createdBy: EntrustedUser;
  createdOn: Date;
  updatedBy: EntrustedUser;
  updatedOn: Date;
  text: string;
  editable: boolean;
  onTextChange: ($event: any) => string;
}
