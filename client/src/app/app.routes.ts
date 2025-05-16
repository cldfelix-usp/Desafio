import { TituloDevedorListaComponent } from './components/titulo-devedor-lista/titulo-devedor-lista.component';
import { TituloDevedorFormComponent } from './components/titulo-devedor-form/titulo-devedor-form.component';
import { Routes } from '@angular/router';


export const routes: Routes = [
  { path: '', redirectTo: '/titulos', pathMatch: 'full' },
  { path: 'titulos', component: TituloDevedorListaComponent },
  { path: 'titulos/novo', component: TituloDevedorFormComponent },
  { path: 'titulos/editar/:id', component: TituloDevedorFormComponent },
  { path: '**', redirectTo: '/titulos' }
];

