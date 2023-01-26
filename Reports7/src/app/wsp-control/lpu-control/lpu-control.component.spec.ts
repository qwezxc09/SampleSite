import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LpuControlComponent } from './lpu-control.component';

describe('LpuControlComponent', () => {
  let component: LpuControlComponent;
  let fixture: ComponentFixture<LpuControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LpuControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LpuControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
