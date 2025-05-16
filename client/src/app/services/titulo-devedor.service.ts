import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TituloDevedor } from '../models/titulo-devedor';

@Injectable({
  providedIn: 'root'
})
export class TituloDevedorService {
  private apiUrl = 'api-desafio:443/api/titulos';

  constructor(private http: HttpClient) { }

  getTitulosDevedores(): Observable<TituloDevedor[]> {
    return this.http.get<TituloDevedor[]>(this.apiUrl);
  }

  addTituloDevedor(tituloDevedor: TituloDevedor): Observable<TituloDevedor> {
    return this.http.post<TituloDevedor>(this.apiUrl, tituloDevedor);
  }
}

