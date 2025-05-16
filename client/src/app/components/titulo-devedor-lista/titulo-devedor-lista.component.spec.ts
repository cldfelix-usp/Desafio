import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TituloDevedorListaComponent } from './titulo-devedor-lista.component';

describe('TituloDevedorListaComponent', () => {
  let component: TituloDevedorListaComponent;
  let fixture: ComponentFixture<TituloDevedorListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TituloDevedorListaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TituloDevedorListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
