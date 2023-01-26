import { TestBed } from '@angular/core/testing';

import { FullDataControlService } from './full-data-control.service';

describe('FullDataControlService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FullDataControlService = TestBed.get(FullDataControlService);
    expect(service).toBeTruthy();
  });
});
