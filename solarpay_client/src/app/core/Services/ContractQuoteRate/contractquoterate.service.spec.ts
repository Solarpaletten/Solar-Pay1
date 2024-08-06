import { TestBed } from '@angular/core/testing';

import { ContractquoterateService } from './contractquoterate.service';

describe('ContractquoterateService', () => {
  let service: ContractquoterateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContractquoterateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
