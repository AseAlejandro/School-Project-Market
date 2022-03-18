import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CuentaService } from '../cuenta/cuenta.service';

@Injectable({
  providedIn: 'root'
})
export class MochilaService {
  myAppUrl: string = 'https://localhost:44302/'

  constructor(
    private http: HttpClient,
    private _cuentaService: CuentaService
  ) { }

  getMochila(id: number): Observable<any>{
    return this.http.get(this.myAppUrl + "api/Mochila?cuentaId=" + id)
  }

  addToMochila(cartRecord: any, id: number): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.post(this.myAppUrl + "api/Mochila?cuentaId=" + id, JSON.stringify(cartRecord), httpOptions);
  }

  updateMochila(mochila: any): Observable<any>{
    return this.http.put(this.myAppUrl + "api/Mochila?cuentaId=" + "1" + "/" + mochila.id, mochila)
  }

  removeMochila(mochila: any, id: number): Observable<any>{
    return this.http.delete(this.myAppUrl + "api/Mochila?cuentaId=" + id + "/" + mochila.id + "/" + encodeURIComponent('"' + mochila.fechaCreacion + '"'));
  }

  cotizar(mochila: any): Observable<any> {
    return this.http.post(this.myAppUrl + "api/Mochila/ordenar", mochila);
  }
}

export interface MochilaRecord{
  id?: number;
  fecha?: any;
  clienteId: number;
  productoId: number;
  cantidad: number;
  costoTotal: number;
  vendedorId?: number;
  precio: number;
}

export class Cart {
  private _cartRecords: any[] =[];

  constructor (cartRecords: any) {
    if (cartRecords){
      this._cartRecords = cartRecords;
    }
  }

  get CartRecords(): any[] {
    return this._cartRecords;
  }

  get CartTotal(): number {
    let total:number = 0;
    this._cartRecords.forEach(function (r) {
        total += r.LineItemTotal;
    });
    return total;
  }

  addToCart(cartRecord: any) {
    this._cartRecords.push(cartRecord);
  }
}

