import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReseñasService {
  myAppUrl: string = 'https://localhost:44302/'

  constructor(
    private http: HttpClient
  ) { }

  getReseñas(): Observable<any> {
    return this.http.get(this.myAppUrl + "api/resenas")
  }

  postReseñas(reseña: any): Observable<any> {
    return this.http.post(this.myAppUrl + "api/Resenas", reseña)
  }

  getReseñaCuenta(id: number): Observable<any> {
    return this.http.get(this.myAppUrl + "api/resenas/" + id)
  }
}
