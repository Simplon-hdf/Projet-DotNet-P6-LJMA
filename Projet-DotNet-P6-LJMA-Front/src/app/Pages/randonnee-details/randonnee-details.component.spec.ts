import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RandonneeDetailsComponent } from './randonnee-details.component';

describe('RandonneeDetailsComponent', () => {
  let component: RandonneeDetailsComponent;
  let fixture: ComponentFixture<RandonneeDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RandonneeDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RandonneeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
