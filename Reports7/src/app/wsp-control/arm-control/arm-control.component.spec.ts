import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArmControlComponent } from './arm-control.component';

describe('ArmControlComponent', () => {
  let component: ArmControlComponent;
  let fixture: ComponentFixture<ArmControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArmControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArmControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
