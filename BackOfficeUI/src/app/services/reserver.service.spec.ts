import { TestBed } from '@angular/core/testing';

import { ReserverService } from './reserver.service';

describe('ReserverService', () => {
  let service: ReserverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReserverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
