import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewClients } from './view-clients';

describe('ViewClients', () => {
  let component: ViewClients;
  let fixture: ComponentFixture<ViewClients>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewClients],
    }).compileComponents();

    fixture = TestBed.createComponent(ViewClients);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
