import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { httpOptions } from 'src/app/components/add-cuenta/add-cuenta.component'

@Injectable({
  providedIn: 'root'
})
export class ProductosService {
  myAppUrl: string = 'https://localhost:44302/'

  constructor(
    private http: HttpClient
  ) { }

  getProductos(): Observable<any>{
    return this.http.get(this.myAppUrl + "api/productos")
  }

  addProducto(producto: any): Observable<any>{
    return this.http.post(this.myAppUrl + "api/productos", producto)
  }

  getProducto(id: any): Observable<any>{
    return this.http.get(this.myAppUrl + "api/productos/" + id)
  }

  modifyProducto(id: any, producto: any): Observable<any>{
    return this.http.put(this.myAppUrl + "api/productos/" + id, producto)
  }

  deleteProducto(id: any): Observable<any>{
    return this.http.delete(this.myAppUrl + "api/productos/" + id)
  }

  searchProducto(search: string): Observable<any>{
    return this.http.get(this.myAppUrl + "api/SearchProducto/" + encodeURIComponent(search))
  }

  productosForVendedor(id: number): Observable<any> {
    return this.http.get(this.myAppUrl + "api/productos/vendedor/" + id)
  }
}
