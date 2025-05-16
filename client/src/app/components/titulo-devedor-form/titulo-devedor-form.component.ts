import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDividerModule } from '@angular/material/divider';

import { TituloDevedorService } from '../../services/titulo-devedor.service';
import { TituloDevedor } from '../../models/titulo-devedor';
import { ParcelaAtraso } from '../../models/parcela-atraso';

@Component({
  selector: 'app-titulo-devedor-form',
  templateUrl: './titulo-devedor-form.component.html',
  styleUrls: ['./titulo-devedor-form.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDividerModule,
    MatSnackBarModule
  ]
})
export class TituloDevedorFormComponent implements OnInit {
  tituloForm!: FormGroup;
  isSubmitting = false;

  constructor(
    private fb: FormBuilder,
    private tituloDevedorService: TituloDevedorService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.tituloForm = this.fb.group({
      numeroTitulo: ['', [Validators.required]],
      nomeDevedor: ['', [Validators.required]],
      cpfDevedor: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      percentualJuros: ['', [Validators.required, Validators.min(0)]],
      percentualMulta: ['', [Validators.required, Validators.min(0)]],
      parcelasEmAtraso: this.fb.array([])
    });

    // Adicionar pelo menos uma parcela em atraso
    this.adicionarParcela();
  }

  get parcelasFormArray(): FormArray {
    return this.tituloForm.get('parcelasEmAtraso') as FormArray;
  }

  novaParcela(): FormGroup {
    return this.fb.group({
      parcelasDivida: ['', [Validators.required, Validators.min(1)]],
      qtdParcelas: ['', [Validators.required, Validators.min(1)]],
      dataVencimento: ['', [Validators.required]],
      valorParcela: ['', [Validators.required, Validators.min(0.01)]]
    });
  }

  adicionarParcela(): void {
    this.parcelasFormArray.push(this.novaParcela());
  }

  removerParcela(index: number): void {
    if (this.parcelasFormArray.length > 1) {
      this.parcelasFormArray.removeAt(index);
    } else {
      this.snackBar.open('É necessário pelo menos uma parcela em atraso', 'Fechar', {
        duration: 3000
      });
    }
  }

  onSubmit(): void {
    if (this.tituloForm.valid) {
      this.isSubmitting = true;

      const tituloDevedor: TituloDevedor = this.tituloForm.value;

      // Formatação da data para o formato esperado pela API
      tituloDevedor.parcelasEmAtraso.forEach((parcela: ParcelaAtraso) => {
        if (parcela.dataVencimento instanceof Date) {
          parcela.dataVencimento = parcela.dataVencimento.toISOString().split('T')[0];
        }
      });

      this.tituloDevedorService.addTituloDevedor(tituloDevedor).subscribe({
        next: (response) => {
          this.snackBar.open('Título devedor cadastrado com sucesso!', 'Fechar', {
            duration: 3000
          });
          this.isSubmitting = false;
          this.router.navigate(['/titulos']);
        },
        error: (error) => {
          console.error('Erro ao cadastrar título:', error);
          this.snackBar.open('Erro ao cadastrar título', 'Fechar', {
            duration: 5000
          });
          this.isSubmitting = false;
        }
      });
    } else {
      this.validateAllFormFields(this.tituloForm);
      this.snackBar.open('Por favor, corrija os erros no formulário', 'Fechar', {
        duration: 3000
      });
    }
  }

  validateAllFormFields(formGroup: FormGroup): void {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      } else if (control instanceof FormArray) {
        for (let i = 0; i < control.length; i++) {
          if (control.at(i) instanceof FormGroup) {
            this.validateAllFormFields(control.at(i) as FormGroup);
          }
        }
      } else {
        control?.markAsTouched({ onlySelf: true });
      }
    });
  }

  cancelar(): void {
    this.router.navigate(['/titulos']);
  }
}
