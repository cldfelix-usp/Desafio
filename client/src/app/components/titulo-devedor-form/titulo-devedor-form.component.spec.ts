import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TituloDevedorFormComponent } from './titulo-devedor-form.component';

describe('TituloDevedorFormComponent', () => {
  let component: TituloDevedorFormComponent;
  let fixture: ComponentFixture<TituloDevedorFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TituloDevedorFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TituloDevedorFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
