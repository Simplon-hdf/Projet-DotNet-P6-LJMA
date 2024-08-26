import { TestBed } from '@angular/core/testing';

import { RandonneeService } from './randonnee.service';

describe('RandonneeService', () => {
  let service: RandonneeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RandonneeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
