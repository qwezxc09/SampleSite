import { TestBed } from '@angular/core/testing';

import { CraneService } from './crane.service';

describe('CraneService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CraneService = TestBed.get(CraneService);
    expect(service).toBeTruthy();
  });
});
