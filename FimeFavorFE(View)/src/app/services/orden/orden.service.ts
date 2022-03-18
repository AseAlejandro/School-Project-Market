import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrdenService {
  myAppUrl: string = 'https://localhost:44302/'

  constructor(
    private http: HttpClient
  ) { }

  getOrdenes(): Observable<any>{
    return this.http.get(this.myAppUrl + "api/orden")
  }

  getOrdenConDetalle(id: number): Observable<any> {
    return this.http.get(this.myAppUrl + "api/orden/" + id)
  }

  getOrdenesSinRepartidor(): Observable<any> {
    return this.http.get(this.myAppUrl + "sinRepartidor")
  }

  getOrdenesRepartidor(id: number): Observable<any> {
    return this.http.get(this.myAppUrl + "api/orden/Repartidor/" + id)
  }

  putOrden(id: number, orden: any): Observable<any> {
    return this.http.put(this.myAppUrl + "api/Orden/" + id, orden)
  }

  getJustOne(id: number): Observable<any> {

    return this.http.get(this.myAppUrl + "JustOne/" + id)
  }
}
