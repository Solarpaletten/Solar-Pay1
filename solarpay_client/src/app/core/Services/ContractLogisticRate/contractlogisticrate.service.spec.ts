import { TestBed } from '@angular/core/testing';

import { ContractlogisticrateService } from './contractlogisticrate.service';

describe('ContractlogisticrateService', () => {
  let service: ContractlogisticrateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContractlogisticrateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
