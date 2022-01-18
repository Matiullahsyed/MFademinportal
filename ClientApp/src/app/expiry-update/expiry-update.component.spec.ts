import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpiryUpdateComponent } from './expiry-update.component';

describe('ExpiryUpdateComponent', () => {
  let component: ExpiryUpdateComponent;
  let fixture: ComponentFixture<ExpiryUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExpiryUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpiryUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
