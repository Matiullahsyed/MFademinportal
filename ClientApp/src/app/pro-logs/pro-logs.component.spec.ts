import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProLogsComponent } from './pro-logs.component';

describe('ProLogsComponent', () => {
  let component: ProLogsComponent;
  let fixture: ComponentFixture<ProLogsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProLogsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProLogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
