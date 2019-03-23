import { CustomerStatus } from './customerStatus';

export class CustomerForm {
        key: string;
        status: CustomerStatus;
        createdOn: Date;
        givenName: string;
        familyName: string;
        address: string;
        email: string;
        phone: string;
        isNewCustomer: boolean;
}