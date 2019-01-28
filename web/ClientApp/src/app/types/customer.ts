import { CustomerStatus } from './customerStatus';

export class Customer {
        key: string;
        status: CustomerStatus;
        createdOn: Date;
        givenName: string;
        familyName: string;
        addressOne: string;
        addressTwo: string;
        city: string;
        state: string;
        zipCode: string;
        email: string;
        phone: string;
        notes: string[];
}