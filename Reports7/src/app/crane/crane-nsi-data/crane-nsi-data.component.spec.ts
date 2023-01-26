import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CraneNsiDataComponent } from './crane-nsi-data.component';

describe('CraneNsiDataComponent', () => {
  let component: CraneNsiDataComponent;
  let fixture: ComponentFixture<CraneNsiDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CraneNsiDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CraneNsiDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
