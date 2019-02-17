import { CustomerStatus } from './customerStatus';

export class Customer {
        key: string;
        status: CustomerStatus;
        createdOn: Date;
        givenName: string;
        familyName: string;
        addressOne: string;
        addressTwo: string;
        state: string;
        zipCode: string;
        email: string;
        phone: string;
}