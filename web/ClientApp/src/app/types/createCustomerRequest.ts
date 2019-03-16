import { CustomerStatus } from "./customerStatus";
import { CustomerNote } from "./customerNote";

export interface CreateCustomerRequest {
    givenName: string;
    familyName: string;
    fullAddress: string;
    phone: string;
    status: CustomerStatus;
    notes: CustomerNote[];
}