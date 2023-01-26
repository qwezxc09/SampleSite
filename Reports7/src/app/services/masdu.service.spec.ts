import { TestBed } from '@angular/core/testing';

import { MasduService } from './masdu.service';

describe('MasduService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MasduService = TestBed.get(MasduService);
    expect(service).toBeTruthy();
  });
});
