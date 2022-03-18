import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { httpOptions } from 'src/app/components/add-cuenta/add-cuenta.component';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  //myAppUrl: string = 'https://fimefavorapi.azure-api.net/'
  myAppUrl: string = 'https://localhost:44302/'

  constructor(private http: HttpClient) { }

  getCategorias(): Observable<any>{
    return this.http.get(this.myAppUrl + 'api/Categorias')
  }

  addCategoria(categoria: any): Observable<any>{
    return this.http.post(this.myAppUrl + 'api/Categorias', categoria)
  }

  getCategoria(id: any): Observable<any>{
    return this.http.get(this.myAppUrl + 'api/Categorias/' + id)
  }

  modifyCategoria(id: any, categoria: any): Observable<any>{
    return this.http.put(this.myAppUrl + 'api/Categorias/' + id, categoria)
  }
  
  deleteCategoria(id: any): Observable<any>{
    return this.http.delete(this.myAppUrl + 'api/Categorias/' + id)
  }

  getProductosCategoria(id: any): Observable<any>{
    return this.http.get(this.myAppUrl + 'api/Categorias/' + id + '/products')
  }
}
