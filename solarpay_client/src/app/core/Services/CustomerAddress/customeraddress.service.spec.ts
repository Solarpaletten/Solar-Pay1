/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CustomeraddressService } from './customeraddress.service';

describe('Service: Customeraddress', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CustomeraddressService]
    });
  });

  it('should ...', inject([CustomeraddressService], (service: CustomeraddressService) => {
    expect(service).toBeTruthy();
  }));
});
