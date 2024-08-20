import { TestBed } from '@angular/core/testing';

import { FormLoginService } from './form-login.service';

describe('FormloginService', () => {
  let service: FormLoginService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormLoginService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
