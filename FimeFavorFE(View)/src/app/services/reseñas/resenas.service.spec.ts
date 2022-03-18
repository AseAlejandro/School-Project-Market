import { TestBed } from '@angular/core/testing';

import { ReseñasService } from './resenas.service';

describe('ReseñasService', () => {
  let service: ReseñasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReseñasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
