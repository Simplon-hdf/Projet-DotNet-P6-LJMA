import { TestBed } from '@angular/core/testing';

import { FormRegisterService } from './form-register.service';

describe('FormRegisterService', () => {
  let service: FormRegisterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormRegisterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
