import { CustomerStatus } from './customerStatus';

export class Customer {
  public key: string;
  public status: CustomerStatus;
  public createdOn: Date;
  public givenName: string;
  public familyName: string;
  public address: string;
  public email: string;
  public phone: string;
}
