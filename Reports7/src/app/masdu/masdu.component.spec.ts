import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MasduComponent } from './masdu.component';

describe('MasduComponent', () => {
  let component: MasduComponent;
  let fixture: ComponentFixture<MasduComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MasduComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MasduComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
