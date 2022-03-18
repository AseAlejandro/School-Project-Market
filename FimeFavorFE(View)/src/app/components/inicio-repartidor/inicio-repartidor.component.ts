import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { OrdenService } from 'src/app/services/orden/orden.service';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { TokenService } from 'src/app/services/token/token.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-inicio-repartidor',
  templateUrl: './inicio-repartidor.component.html',
  styleUrls: ['./inicio-repartidor.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class InicioRepartidorComponent implements OnInit {
  ordenes: [] = [];
  orden: any = "";
  header: string = "";
  categorias: any[] = [];
  displayedColumns: string[] = ["fecha", "clienteId", "repartidorId", "lugarDeEntrega", "comentarios", "total"]
  expandedElement: ListaOrden | null | undefined;
  currentUser: any[] = [];
  form!: FormGroup;
  id: number = 0;

  constructor(
    private route: ActivatedRoute,
    private _productoService: ProductosService,
    private _categoriaService: CategoriaService,
    private router: Router,
    private _ordenService: OrdenService,
    private token: TokenService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.header = "Ordenes"
    this._ordenService.getOrdenesSinRepartidor().subscribe(ordenes =>
      this.ordenes = ordenes)
      this.currentUser = this.token.getUser();
      console.log(this.currentUser)
  }

  aceptarPedido(id: number){
    this._ordenService.getJustOne(id).subscribe(data =>{
      this.orden = data[0]
      console.log(data)
      console.log(this.orden)
      this.currentUser = this.token.getUser();
      this.id = this.currentUser[0].id;
      const ordenNueva: any = {
        id: this.orden.id,
        fecha: this.orden.fecha,
        total: this.orden.total,
        lugarDeEntrega: this.orden.lugarDeEntrega,
        repartidorId: this.id,
        comentarios: this.orden.comentarios,
        metodoDePago: this.orden.metodoDePago,
        clienteId: this.orden.clienteId
      }
      console.log(ordenNueva)
      this._ordenService.putOrden(id, ordenNueva).subscribe(data => {
        this.router.navigate(['/ordenesAceptadas'])
      })
    })
  }

}

export interface ListaOrden {
  id: number,
  clienteId: number
}
