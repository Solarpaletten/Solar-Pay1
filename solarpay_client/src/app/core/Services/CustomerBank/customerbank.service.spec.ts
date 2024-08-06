/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CustomerbankService } from './customerbank.service';

describe('Service: Customerbank', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CustomerbankService]
    });
  });

  it('should ...', inject([CustomerbankService], (service: CustomerbankService) => {
    expect(service).toBeTruthy();
  }));
});
