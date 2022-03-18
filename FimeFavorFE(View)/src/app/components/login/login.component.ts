import { Token } from '@angular/compiler/src/ml_parser/lexer';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { data } from 'jquery';
import { ToastrService } from 'ngx-toastr';
import { CuentaService } from 'src/app/services/cuenta/cuenta.service';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  logins: any[] = [];
  accion = 'Agregar';
  form!: FormGroup;
  password: string = "";
  nombre: string ="";
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];
  currentUser: any[] = []

  constructor(
    private fb: FormBuilder,
    private _cuentaService: CuentaService,
    private router: Router,
    private tokenStorage: TokenService,
    private toastr: ToastrService
  ) 
  { 
    this.form = this.fb.group({
      correo: ['', Validators.required],
      contrasena: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.currentUser = this.tokenStorage.getUser();
  }

  login() {
    const cuenta: any = {
      correo: this.form.get('correo')?.value,
      contrasena: this.form.get('contrasena')?.value
    }
    this._cuentaService.getCuenta(cuenta.correo).subscribe(data => {
      this.tokenStorage.saveToken(data.accessToken);
      this.tokenStorage.saveUser(data)
      this.password = data[0].contrasena
      if(this.password == cuenta.contrasena)
      {
        this.nombre = data[0].nombre
        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.roles = this.tokenStorage.getUser().roles;
        //this.reloadPage();
        this.toastr.success('Inicio de sesion correcto', 'Click en continuar');
      }
      else{
        this.isLoginFailed = true;
        this.toastr.error('Inicio de sesion equivocado, confirme su cuenta y contraseña','Error')
      }
      console.log(data[0])
    })
  }

  reloadPage(): void {
    window.location.reload();
  }
}

export interface cuentas {
  id?: number
  matricula?: string
  nombre: string
  correo?: string
  contrasena?: string
}


  /*guardarCuenta() {
    const cuenta: any = {
      correo: this.form.get('correo')?.value,
      contrasena: this.form.get('contrasena')?.value
    }
    this._cuentaService.addCuenta(cuenta).subscribe(data=>{
      this.form.reset();
    })
  }
  //Login
  loginTry() {
    const cuenta: any = {
      correo: this.form.get('correo')?.value,
      contrasena: this.form.get('contrasena')?.value
    }
    this._cuentaService.login(cuenta).subscribe(data => {
      this._cuentaService.setToken(data.token);
      this.router.navigateByUrl('/');
    })
  }*/
