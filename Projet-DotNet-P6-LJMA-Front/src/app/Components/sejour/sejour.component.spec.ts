import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SejourComponent } from './sejour.component';

describe('SejourComponent', () => {
  let component: SejourComponent;
  let fixture: ComponentFixture<SejourComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SejourComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SejourComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
