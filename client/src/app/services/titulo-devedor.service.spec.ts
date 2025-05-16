import { TestBed } from '@angular/core/testing';

import { TituloDevedorService } from './titulo-devedor.service';

describe('TituloDevedorService', () => {
  let service: TituloDevedorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TituloDevedorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
