import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-seleccion',
  templateUrl: './seleccion.component.html',
  styleUrls: ['./seleccion.component.css']
})
export class SeleccionComponent implements OnInit {
  nombre: string ="";
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];
  currentUser: any[] = []

  constructor(
    private tokenStorage: TokenService,
    private router : Router,
  ) { }

  ngOnInit(): void {
    this.currentUser = this.tokenStorage.getUser();
    this.nombre = this.currentUser[0].nombre
  }

  cerrarSesion(){
    this.tokenStorage.signOut();
    this.router.navigate(['/login']);
  }

}
