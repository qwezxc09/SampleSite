import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CraneReportDataComponent } from './crane-report-data.component';

describe('CraneReportDataComponent', () => {
  let component: CraneReportDataComponent;
  let fixture: ComponentFixture<CraneReportDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CraneReportDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CraneReportDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
