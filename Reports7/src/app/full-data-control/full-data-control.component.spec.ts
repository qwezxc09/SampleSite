import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FullDataControlComponent } from './full-data-control.component';

describe('FullDataControlComponent', () => {
  let component: FullDataControlComponent;
  let fixture: ComponentFixture<FullDataControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FullDataControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FullDataControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
