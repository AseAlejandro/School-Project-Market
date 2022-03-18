import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ReseñasService } from 'src/app/services/reseñas/resenas.service';

@Component({
  selector: 'app-add-resena',
  templateUrl: './add-resena.component.html',
  styleUrls: ['./add-resena.component.css']
})
export class AddResenaComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private toastr: ToastrService,
    private fb: FormBuilder,
    private _resenaService: ReseñasService,
    private router: Router,
  ) 
  { 
    this.form = this.fb.group({
      descripcion: ['', Validators.required],
      cuentaId: ['', Validators.required],
      calificacion: ['', Validators.required]
    })
  }

  ngOnInit(): void {
  }

  guardar(){
    const resena: any = {
      descripcion: this.form.get('descripcion')?.value,
      cuentaId: this.form.get('cuentaId')?.value,
      calificacion: this.form.get('calificacion')?.value
    }
    this._resenaService.postReseñas(resena).subscribe(data=>{
      this.form.reset();
    })
    console.log(resena);
  }

}
