import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { httpOptions } from 'src/app/components/add-cuenta/add-cuenta.component'

@Injectable({
  providedIn: 'root'
})
export class CuentaService {
  //myAppUrl: string = 'http://fimefavorapi.azure-api.net/'
  myAppUrl: string = 'https://localhost:44302/'

  constructor(
    private http: HttpClient,
    private cookies: CookieService) { }

  getCuentas(): Observable<any>{
    return this.http.get(this.myAppUrl + 'api/cuentas')
  }

  addCuenta(cuenta: any): Observable<any>{
    return this.http.post(this.myAppUrl + 'api/cuentas', cuenta, httpOptions)
  }

  getCuenta(cuenta: string): Observable<any>{
    return this.http.get(this.myAppUrl + 'api/cuentas/' + cuenta)
  }

  //Codigo para el login
  login(user: any):Observable<any> {
    return this.http.post(this.myAppUrl + 'api/cuentas', user)
  }

  register(user: any):Observable<any> {
    return this.http.post(this.myAppUrl + "api/cuentas", user)
  }

  setToken(token: any) {
    this.cookies.set("token", token);
  }

  getToken() {
    return this.cookies.get("token");
  }

  getCuenta1() {
    return this.http.get(this.myAppUrl + 'api/cuentas/' + 1);
  }
  
  getUserLogged() {
    const token = this.getToken();
    // Aquí iría el endpoint para devolver el usuario para un token
  }
}
