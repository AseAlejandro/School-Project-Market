import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { NavigationExtras, Router } from '@angular/router';
import { MochilaService } from 'src/app/services/mochila/mochila.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  form!: FormGroup;
  carritos: any[] = [];
  lugaresDeEntrega: lugarDeEntrega[] = [
    new lugarDeEntrega("1", "Edificio1"),
    new lugarDeEntrega("2", "Edificio2"),
    new lugarDeEntrega("3", "Edificio3"),
  ]
  metodosDePago: metodoDePago[] = [
    new metodoDePago("1", "Efectivo"),
    new metodoDePago("2", "Tarjeta"),
    new metodoDePago("3", "Transferencia")
  ]
  categorias: any[] = [];
  searchText: string ="";
  currentUser: any[] = []
  id: number = 0

  constructor(
    private toastr: ToastrService,
    private fb: FormBuilder,
    private router: Router,
    private _mochilaService: MochilaService,
    private _categoriaService: CategoriaService,
    private tokenStorage: TokenService
  ) 
  { 
    this.form = this.fb.group({
      clienteId: ['', Validators.required],
      lugarDeEntrega: ['', Validators.required],
      comentarios: ['', Validators.required],
      metodoDePago: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.currentUser = this.tokenStorage.getUser();
    this.id = this.currentUser[0].id
    this._categoriaService.getCategorias().subscribe(categorias =>
      this.categorias = categorias)
    this.form = this.fb.group({
      clienteId: [this.id],
      lugarDeEntrega: ['', Validators.required],
      comentarios: ['', Validators.required],
      metodoDePago: ['', Validators.required]
    })
      
  }

  cotizar() {
    const datos: any = {
      clienteId: this.form.get('clienteId')?.value,
      lugarDeEntrega: this.form.get('lugarDeEntrega')?.value,
      comentarios: this.form.get('comentarios')?.value,
      metodoDePago: this.form.get('metodoDePago')?.value
    }
    console.log(datos)
    this._mochilaService.cotizar(datos).subscribe((response) => {
      if(response.status == 201){
        this.router.navigate(['/mercado']);
      }
    }, err => this.router.navigate(['/espera']) )
  }

  search() {
    let navigationExtras: NavigationExtras = {
    queryParams: { 'searchText': this.searchText }
  };

  this.router.navigate(['/mercado'], navigationExtras);
  }

}

export class lugarDeEntrega {
  id: string;
  name: string;
 
  constructor(id: string, name: string) {
    this.id = id;
    this.name = name;
  }
}

export class metodoDePago {
  id: string;
  name: string;
 
  constructor(id: string, name: string) {
    this.id = id;
    this.name = name;
  }
}
