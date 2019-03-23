import { EntrustedUser } from './entrustedUser';

export class CustomerNote {    
    customerKey: string;
    createdBy: EntrustedUser;
    createdOn: Date;
    updatedBy: EntrustedUser;
    updatedOn: Date;
    text: string;
}