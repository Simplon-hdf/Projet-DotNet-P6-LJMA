import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RandonneeComponent } from './randonnee.component';

describe('RandonneeComponent', () => {
  let component: RandonneeComponent;
  let fixture: ComponentFixture<RandonneeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RandonneeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RandonneeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
