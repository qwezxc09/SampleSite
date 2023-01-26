import { TestBed } from '@angular/core/testing';

import { TagListService } from './tag-list.service';

describe('TagListService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TagListService = TestBed.get(TagListService);
    expect(service).toBeTruthy();
  });
});
