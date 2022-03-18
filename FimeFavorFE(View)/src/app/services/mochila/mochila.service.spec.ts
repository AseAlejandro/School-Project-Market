import { TestBed } from '@angular/core/testing';

import { MochilaService } from './mochila.service';

describe('MochilaService', () => {
  let service: MochilaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MochilaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
