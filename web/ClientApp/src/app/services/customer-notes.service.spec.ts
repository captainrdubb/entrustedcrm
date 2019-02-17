import { TestBed, inject } from '@angular/core/testing';

import { CustomerNotesService } from './customer-notes.service';

describe('CustomerNotesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CustomerNotesService]
    });
  });

  it('should be created', inject([CustomerNotesService], (service: CustomerNotesService) => {
    expect(service).toBeTruthy();
  }));
});
