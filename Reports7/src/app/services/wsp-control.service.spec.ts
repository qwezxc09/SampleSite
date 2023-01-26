import { TestBed } from '@angular/core/testing';

import { WspControlService } from './wsp-control.service';

describe('WspControlService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WspControlService = TestBed.get(WspControlService);
    expect(service).toBeTruthy();
  });
});
