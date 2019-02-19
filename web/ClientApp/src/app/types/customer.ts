import { CustomerStatus } from './customerStatus';

export class Customer {
        key: string;
        status: CustomerStatus;
        createdOn: Date;
        givenName: string;
        familyName: string;
        address: string;
        email: string;
        phone: string;
}