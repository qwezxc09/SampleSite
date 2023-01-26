import { TestBed } from '@angular/core/testing';

import { AutoSystemService } from './auto-system.service';

describe('AutoSystemService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AutoSystemService = TestBed.get(AutoSystemService);
    expect(service).toBeTruthy();
  });
});
