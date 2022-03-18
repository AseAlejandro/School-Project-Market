import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ProductosService } from 'src/app/services/productos/productos.service';
import { CategoriaService } from 'src/app/services/categoria/categoria.service';
import { OrdenService } from 'src/app/services/orden/orden.service';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { TokenService } from 'src/app/services/token/token.service';

@Component({
  selector: 'app-ordenes-aceptadas',
  templateUrl: './ordenes-aceptadas.component.html',
  styleUrls: ['./ordenes-aceptadas.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class OrdenesAceptadasComponent implements OnInit {
  ordenes: [] = [];
  orden: any = "";
  header: string = "";
  categorias: any[] = [];
  displayedColumns: string[] = ["fecha", "clienteId", "repartidorId", "lugarDeEntrega", "comentarios", "total"]
  expandedElement: ListaOrden | null | undefined;
  currentUser: any[] = [];
  id: number = 0

  constructor(
    private route: ActivatedRoute,
    private _productoService: ProductosService,
    private _categoriaService: CategoriaService,
    private router: Router,
    private _ordenService: OrdenService,
    private token: TokenService
  ) { }

  ngOnInit(): void {
    this.header = "Mis ordenes"
    this.currentUser = this.token.getUser();
    this.id = this.currentUser[0].id
    this._ordenService.getOrdenesRepartidor(this.id).subscribe(ordenes =>
      this.ordenes = ordenes)
  }

}

export interface ListaOrden {
  id: number,
  clienteId: number
}

