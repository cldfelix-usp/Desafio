import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { TituloDevedor } from '../../models/titulo-devedor';
import { TituloDevedorService } from '../../services/titulo-devedor.service';

@Component({
  selector: 'app-titulo-devedor-lista',
  templateUrl: './titulo-devedor-lista.component.html',
  styleUrls: ['./titulo-devedor-lista.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatSnackBarModule
  ]
})

export class TituloDevedorListaComponent{
  displayedColumns: string[] = [
    'numeroTitulo',
    'nomeDevedor',
    'parcelasEmAtraso',
    'valorOriginal',
    'diasEmAtrazo'
  ];

  dataSource: MatTableDataSource<TituloDevedor> = new MatTableDataSource<TituloDevedor>([]);
  isLoading = false;


  constructor(
    private tituloDevedorService: TituloDevedorService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.carregarTitulos();
  }


  carregarTitulos(): void {
    this.isLoading = true;
    this.tituloDevedorService.getTitulosDevedores().subscribe({
      next: (titulos) => {
        this.dataSource = new MatTableDataSource(titulos);
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Erro ao carregar títulos:', error);
        this.snackBar.open('Erro ao carregar títulos', 'Fechar', {
          duration: 5000
        });
        this.isLoading = false;
      }
    });
  }




  getTotalParcelas(titulo: TituloDevedor): number {
    return titulo.parcelasEmAtraso.length;
  }
}
