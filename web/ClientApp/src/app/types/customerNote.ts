import { EntrustedUser } from './entrustedUser';

export class CustomerNote {
  key: string;
  customerKey: string;
  createdBy: EntrustedUser;
  createdOn: Date;
  updatedBy: EntrustedUser;
  updatedOn: Date;
  text: string;
}
