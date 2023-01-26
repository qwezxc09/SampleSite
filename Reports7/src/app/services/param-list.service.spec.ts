import { TestBed } from '@angular/core/testing';

import { ParamListService } from './param-list.service';

describe('ParamListService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ParamListService = TestBed.get(ParamListService);
    expect(service).toBeTruthy();
  });
});
