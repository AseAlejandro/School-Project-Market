import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CuentaService } from 'src/app/services/cuenta/cuenta.service';

@Component({
  selector: 'app-add-cuenta',
  templateUrl: './add-cuenta.component.html',
  styleUrls: ['./add-cuenta.component.css']
})
export class AddCuentaComponent implements OnInit {
  listCuentas: any[] = [];
  accion = 'Agregar';
  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private _cuentaService: CuentaService,
    private router: Router
  ) 
  {
    this.form = this.fb.group({
      matricula: ['', Validators.required],
      nombre: ['', Validators.required],
      correo: ['', Validators.required],
      contrasena: ['', Validators.required]
    })
   }

  ngOnInit(): void {
  }

  guardarCuenta() {
    const cuenta: any = {
      matricula: this.form.get('matricula')?.value,
      nombre: this.form.get('nombre')?.value,
      correo: this.form.get('correo')?.value,
      contrasena: this.form.get('contrasena')?.value
    }
    this._cuentaService.addCuenta(cuenta).subscribe(data=>{
      this.form.reset();
    })
    console.log(cuenta)
    console.log(httpOptions)
  }

  register() {
    const cuenta: any = {
      matricula: this.form.get('matricula')?.value,
      nombre: this.form.get('nombre')?.value,
      correo: this.form.get('correo')?.value,
      contrasena: this.form.get('contrasena')?.value
    }
    this._cuentaService.register(cuenta).subscribe(data => {
      this._cuentaService.setToken(data.token);
      this.router.navigateByUrl('/');
    },
    error=>{
      console.log(error)
    })
  }
}

export const httpOptions = {
  headers: new HttpHeaders({
    'Ocp-Apm-Subscription-Key': '570c3e3c37e94eb185cd715d7de9eaa3',
    'Ocp-Apim-Trace': 'true'
  })
};
