import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KcControlComponent } from './kc-control.component';

describe('KcControlComponent', () => {
  let component: KcControlComponent;
  let fixture: ComponentFixture<KcControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KcControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KcControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
