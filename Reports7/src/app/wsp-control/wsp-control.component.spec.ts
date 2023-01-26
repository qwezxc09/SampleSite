import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WspControlComponent } from './wsp-control.component';

describe('WspControlComponent', () => {
  let component: WspControlComponent;
  let fixture: ComponentFixture<WspControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WspControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WspControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
