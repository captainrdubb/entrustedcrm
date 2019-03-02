import { CustomerStatus } from "./customerStatus";

export interface CreateCustomerRequest {
    givenName: string;
    familyName: string;
    fullAddress: string;
    phone: string;
    status: CustomerStatus;
}